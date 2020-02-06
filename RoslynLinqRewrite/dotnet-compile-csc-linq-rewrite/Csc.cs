// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.IO;
//using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.CodeAnalysis.CommandLine;
using IVsSqmMulti = System.Object;

namespace Microsoft.CodeAnalysis.CSharp.CommandLine
{
    internal sealed class Csc : CSharpCompiler
    {
        internal Csc(string responseFile, BuildPathsAlt buildPaths, string[] args, IAnalyzerAssemblyLoader analyzerLoader)
            : base(CSharpCommandLineParser.Default, responseFile, args, buildPaths.ClientDirectory, buildPaths.WorkingDirectory, buildPaths.SdkDirectory, Environment.GetEnvironmentVariable("LIB"), analyzerLoader)
        {
            BackupAnalyzerLoader = analyzerLoader;
            BackupArgs = args;
            BackupBuildPaths = buildPaths;
            BackupResponseFile = responseFile;
        }

        internal static int Run(string[] args, BuildPathsAlt buildPaths, TextWriter textWriter, IAnalyzerAssemblyLoader analyzerLoader)
        {
            ReflFatalError.set_Handler(FailFast.OnFatalException);

            var responseFile = Path.Combine(buildPaths.ClientDirectory, ResponseFileName);
            var compiler = new Csc(responseFile, buildPaths, args, analyzerLoader);
            return ConsoleUtil.RunWithUtf8Output(compiler.Arguments.Utf8Output, textWriter, tw => compiler.Run(tw));
        }

        protected override uint GetSqmAppId() => 0;

        protected override void CompilerSpecificSqm(IVsSqmMulti sqm, uint sqmSession) {}
    }
}
