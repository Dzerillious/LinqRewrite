using System;
using System.Collections.Generic;
using System.IO;
using Shaman.Runtime;

namespace Shaman.Roslyn.LinqRewrite.Services
{
    public class MsBuildService
    {
        private static MsBuildService _instance;
        public static MsBuildService Instance => _instance ??= new MsBuildService();

        public void RunMsbuild(List<object> args)
        {
            var argsArray = args.ToArray();
            var msbuildCandidates = GetMsBuildCandidates(argsArray);
            try
            {
                ProcessUtils.RunPassThrough("msbuild", argsArray);
            }
            catch (Exception ex) when (!(ex is ProcessException))
            {
                foreach (var candidate in msbuildCandidates)
                {
                    var path = Environment.ExpandEnvironmentVariables(candidate);
                    if (File.Exists(path))
                    {
                        ProcessUtils.RunPassThrough(path, argsArray);
                        return;
                    }

                    if (!path.Contains("\\amd64")) continue;
                    path = path.Replace("\\amd64", string.Empty);
                    
                    if (!File.Exists(path)) continue;
                    ProcessUtils.RunPassThrough(path, argsArray);
                    return;
                }
                ProcessUtils.RunPassThrough("xbuild", argsArray);
            }
        }

        private List<string> GetMsBuildCandidates(object[] argsArray)
        {
            var msbuildCandidates = new List<string> {
                @"%ProgramFiles(x86)%\Microsoft Visual Studio\Preview\Enterprise\MSBuild\15.0\Bin\amd64\MSBuild.exe",
                @"%ProgramFiles(x86)%\Microsoft Visual Studio\Preview\Professional\MSBuild\15.0\Bin\amd64\MSBuild.exe",
                @"%ProgramFiles(x86)%\Microsoft Visual Studio\Preview\Community\MSBuild\15.0\Bin\amd64\MSBuild.exe",
                @"%ProgramFiles(x86)%\Microsoft Visual Studio\VS16\MSBuild\16.0\Bin\amd64\MSBuild.exe",
                @"%ProgramFiles(x86)%\Microsoft Visual Studio\VS15\MSBuild\15.0\Bin\amd64\MSBuild.exe",
                @"%ProgramFiles(x86)%\Microsoft Visual Studio\VS15Preview\MSBuild\15.0\Bin\amd64\MSBuild.exe",
                @"%ProgramFiles(x86)%\MSBuild\15.0\Bin\amd64\MSBuild.exe",
                @"%ProgramFiles(x86)%\MSBuild\14.0\Bin\amd64\MSBuild.exe",
                @"%ProgramFiles(x86)%\MSBuild\12.0\Bin\amd64\MSBuild.exe",
                @"%SystemRoot%\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe",
            };
            try
            {
                var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\VisualStudio\SxS", false);
                if (key != null)
                    foreach (var subKey in key.GetSubKeyNames())
                    {
                        var registryKey = key.OpenSubKey(subKey);
                        var ids = registryKey.GetValueNames();
                        foreach (var id in ids)
                        {
                            var path = registryKey.GetValue(id) as string;
                            if (string.IsNullOrEmpty(path)) continue;
                            
                            msbuildCandidates.Add(Path.Combine(path, @"MSBuild\17.0\Bin\amd64\MSBuild.exe"));
                            msbuildCandidates.Add(Path.Combine(path, @"MSBuild\16.0\Bin\amd64\MSBuild.exe"));
                            msbuildCandidates.Add(Path.Combine(path, @"MSBuild\15.0\Bin\amd64\MSBuild.exe"));
                        }
                    }
            }
            catch
            {
                // ignored
            }
            return msbuildCandidates;
        }
    }
}