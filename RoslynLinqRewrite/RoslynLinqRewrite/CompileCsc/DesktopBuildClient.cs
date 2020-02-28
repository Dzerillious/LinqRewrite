﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.
#if DESKTOP
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Microsoft.CodeAnalysis.CommandLine
{
    internal class DesktopBuildClient : BuildClient
    {
        // ReSharper disable once NotAccessedField.Local
        private readonly RequestLanguage _language;
        private readonly CompileFunc _compileFunc;
        private readonly IAnalyzerAssemblyLoader _analyzerAssemblyLoader;

        internal DesktopBuildClient(RequestLanguage language, CompileFunc compileFunc, IAnalyzerAssemblyLoader analyzerAssemblyLoader)
        {
            _language = language;
            _compileFunc = compileFunc;
            _analyzerAssemblyLoader = analyzerAssemblyLoader;
        }

        internal static int Run(IEnumerable<string> arguments, IEnumerable<string> extraArguments, RequestLanguage language, CompileFunc compileFunc, IAnalyzerAssemblyLoader analyzerAssemblyLoader)
        {
            var client = new DesktopBuildClient(language, compileFunc, analyzerAssemblyLoader);
            var clientDir = AppDomain.CurrentDomain.BaseDirectory;
            var sdkDir = RuntimeEnvironment.GetRuntimeDirectory();
            var workingDir = Directory.GetCurrentDirectory();
            var tempPath = Path.GetTempPath();
            var buildPaths = new BuildPathsAlt(clientDir: clientDir, workingDir: workingDir, sdkDir: sdkDir, tempDir: tempPath);
            var originalArguments = GetCommandLineArgs(arguments).Concat(extraArguments).ToArray();
            return client.RunCompilation(originalArguments, buildPaths).ExitCode;
        }

        protected override int RunLocalCompilation(string[] arguments, BuildPathsAlt buildPaths, TextWriter textWriter)
            => _compileFunc(arguments, buildPaths, textWriter, _analyzerAssemblyLoader);

        protected override string GetSessionKey(BuildPathsAlt buildPaths) => string.Empty;
    }
}
#endif