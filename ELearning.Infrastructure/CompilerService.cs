using ELearning.Application.Interfaces;
using ELearning.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Infrastructure
{
    public class CompilerService : ICompilerService
    {
        private const string AbsolutePathToCompilerExeFileConfigurationName = "CompilerAbsolutePath";

        private readonly Process _compiler;
        
        public CompilerService()
        {
            _compiler = SetupCompiler();
        }

        private Process SetupCompiler()
        {
            return new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = SetCompilerPath(),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
        }

        private string SetCompilerPath()
        {
            var basePath = Directory.GetCurrentDirectory() + string.Format("{0}..{0}ELearning.WebUI", Path.DirectorySeparatorChar);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.Local.json", optional: true)
                .Build();

            var compilerPath = configuration.GetValue<string>(AbsolutePathToCompilerExeFileConfigurationName);

            if (string.IsNullOrEmpty(compilerPath))
                throw new ArgumentException($"Absolute path to compiler exe file '{AbsolutePathToCompilerExeFileConfigurationName}' is null or empty.", nameof(compilerPath));

            return compilerPath;
        }

        public async Task<string> CompileAsync(string code, FileSettings fileSettings, CancellationToken cancellationToken)
        {
            var output = "test";

            _compiler.StartInfo.WorkingDirectory = fileSettings.FileSaveDirectory;
            _compiler.StartInfo.Arguments = string.Format("-o {0} {1}", fileSettings.FileNameWithoutExtension, fileSettings.FileName);

            _compiler.Start();
            while (!_compiler.StandardOutput.EndOfStream)
            {
                string line = await _compiler.StandardOutput.ReadLineAsync();
                // do something with line
            }

            return output;
        }
    }
}
