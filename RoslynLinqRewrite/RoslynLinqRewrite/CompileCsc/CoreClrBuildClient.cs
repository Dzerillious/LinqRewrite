﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;

namespace LinqRewrite.CompileCsc
{
    /// <summary>
    /// Client class that handles communication to the server.
    /// </summary>
    internal sealed class CoreClrBuildClient : BuildClient
    {
        private readonly RequestLanguage _language;
        private readonly CompileFunc _compileFunc;

        private CoreClrBuildClient(RequestLanguage language, CompileFunc compileFunc)
        {
            _language = language;
            _compileFunc = compileFunc;
        }

        internal static int Run(IEnumerable<string> arguments, RequestLanguage language, CompileFunc compileFunc)
        {
            // Should be using BuildClient.GetCommandLineArgs(arguments) here.  But the native invoke
            // ends up giving us both CoreRun and the exe file.  Need to find a good way to remove the host
            // as well as the EXE argument.
            // https://github.com/dotnet/roslyn/issues/6677
            var client = new CoreClrBuildClient(language, compileFunc);
            var clientDir = AppContext.BaseDirectory;
            var workingDir = Directory.GetCurrentDirectory();
            var buildPaths = new BuildPathsAlt(clientDir: clientDir, workingDir: workingDir, sdkDir: null, tempDir: null);
            return client.RunCompilation(arguments, buildPaths).ExitCode;
        }

        protected override int RunLocalCompilation(string[] arguments, BuildPathsAlt buildPaths, TextWriter textWriter)
        {
            return _compileFunc(arguments, buildPaths, textWriter,
#if DESKTOP
                new DesktopAnalyzerAssemblyLoader()
#else
                ReflCoreClrAnalyzerAssemblyLoader.ctor()
#endif
                );
        }

        protected override string GetSessionKey(BuildPathsAlt buildPaths)
        {
            return string.Empty;
        }

    }
}
