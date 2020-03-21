using System.IO;
using Microsoft.CodeAnalysis;

namespace LinqRewrite.CompileCsc
{
	internal delegate int CompileFunc2(string[] arguments, object buildPaths, TextWriter textWriter, IAnalyzerAssemblyLoader analyzerAssemblyLoader);
}
