// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace LinqRewrite.CompileCsc
{
    internal delegate int CompileFunc(string[] arguments, BuildPathsAlt buildPaths, TextWriter textWriter, IAnalyzerAssemblyLoader analyzerAssemblyLoader);

    internal struct BuildPathsAlt
    {
        /// <summary>
        /// The path which contains the compiler binaries and response files.
        /// </summary>
        internal string ClientDirectory { get; }

        /// <summary>
        /// The path in which the compilation takes place.
        /// </summary>
        internal string WorkingDirectory { get; }

        /// <summary>
        /// The path which contains mscorlib.  This can be null when specified by the user or running in a 
        /// CoreClr environment.
        /// </summary>
        internal string SdkDirectory { get; }
        internal string TempDirectory { get; }

        internal BuildPathsAlt(string clientDir, string workingDir, string sdkDir, string tempDir)
        {
            ClientDirectory = clientDir;
            WorkingDirectory = workingDir;
            SdkDirectory = sdkDir;
            TempDirectory = tempDir;
        }
    }

    internal struct RunCompilationResult
    {
        internal static readonly RunCompilationResult Succeeded = new RunCompilationResult(CommonCompiler.Succeeded);

        internal static readonly RunCompilationResult Failed = new RunCompilationResult(CommonCompiler.Failed);

        internal int ExitCode { get; }

        internal bool RanOnServer { get; }

        internal RunCompilationResult(int exitCode, bool ranOnServer = false)
        {
            ExitCode = exitCode;
            RanOnServer = ranOnServer;
        }
    }

    /// <summary>
    /// Client class that handles communication to the server.
    /// </summary>
    internal abstract class BuildClient
    {
        protected static bool IsRunningOnWindows => Path.DirectorySeparatorChar == '\\';

        /// <summary>
        /// Run a compilation through the compiler server and print the output
        /// to the console. If the compiler server fails, run the fallback
        /// compiler.
        /// </summary>
        internal RunCompilationResult RunCompilation(IEnumerable<string> originalArguments, BuildPathsAlt buildPaths, TextWriter textWriter = null)
        {
            textWriter ??= Console.Out;

            var args = originalArguments.Select(arg => arg.Trim()).ToArray();

            if (!ReflCommandLineParser.TryParseClientArgs(
                    args, out var parsedArgs, out _, out _, out _, out var errorMessage))
            {
                Console.Out.WriteLine(errorMessage);
                return RunCompilationResult.Failed;
            }

            // It's okay, and expected, for the server compilation to fail.  In that case just fall 
            // back to normal compilation. 
            var exitCode = RunLocalCompilation(parsedArgs.ToArray(), buildPaths, textWriter);
            return new RunCompilationResult(exitCode);
        }

        public Task<RunCompilationResult> RunCompilationAsync(IEnumerable<string> originalArguments, BuildPathsAlt buildPaths, TextWriter textWriter = null)
        {
            var tcs = new TaskCompletionSource<RunCompilationResult>();

            var thread = new Thread(ThreadStart);
            thread.Start();

            return tcs.Task;
            void ThreadStart()
            {
                try
                {
                    var result = RunCompilation(originalArguments, buildPaths, textWriter);
                    tcs.SetResult(result);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }
        }

        protected abstract int RunLocalCompilation(string[] arguments, BuildPathsAlt buildPaths, TextWriter textWriter);

        protected abstract string GetSessionKey(BuildPathsAlt buildPaths);

        protected static IEnumerable<string> GetCommandLineArgs(IEnumerable<string> args)
        {
            return IsRunningOnWindows 
                ? GetCommandLineWindows(args).Where(x => x != "--csc") 
                : args;
        }

        /// <summary>
        /// When running on Windows we can't take the commmand line which was provided to the 
        /// Main method of the application.  That will go through normal windows command line 
        /// parsing which eliminates artifacts like quotes.  This has the effect of normalizing
        /// the below command line options, which are semantically different, into the same
        /// value:
        ///
        ///     /reference:a,b
        ///     /reference:"a,b"
        ///
        /// To get the correct semantics here on Windows we parse the original command line 
        /// provided to the process. 
        /// </summary>
        private static IEnumerable<string> GetCommandLineWindows(IEnumerable<string> args)
        {
            var ptr = Compatibility.GetCommandLine();
            if (ptr == IntPtr.Zero) return args;

            // This memory is owned by the operating system hence we shouldn't (and can't)
            // free the memory.  
            var commandLine = Marshal.PtrToStringUni(ptr);

            // The first argument will be the executable name hence we skip it. 
            return CommandLineParser.SplitCommandLineIntoArguments(commandLine, removeHashComments: false).Skip(1);
        }
    }
}
