// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

namespace LinqRewrite.CompileCsc
{
    public class ProgramLinqRewrite
    {
        
        public static int MainInternal(string[] args)
        {
#if DESKTOP
            return DesktopBuildClient.Run(args, Array.Empty<string>(), RequestLanguage.CSharpCompile, Csc.Run, new DesktopAnalyzerAssemblyLoader());
#else
            return CoreClrBuildClient.Run(args, RequestLanguage.CSharpCompile, new CompileFunc(Csc.Run));
#endif
        }

    }
}
