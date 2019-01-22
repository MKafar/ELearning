using ELearning.Application.Interfaces;
using ELearning.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Infrastructure
{
    public class CompilerService : ICompilerService
    {
        private const string AbsolutePathToCompilerExeFileConfigurationName = "C++CompilerAbsolutePath";

        private string SetCompilerPathFromAppsettingsJson()
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

        public async Task<string> CompileAsync(IFileSettings fileSettings, CancellationToken cancellationToken)
        {
            IList<string> processOutputInAList = new List<string>();
            StringBuilder processOutput = new StringBuilder();

            var processStartInfo = new ProcessStartInfo
            {
                FileName = SetCompilerPathFromAppsettingsJson(),
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WorkingDirectory = fileSettings.FileSaveDirectory,
                Arguments = string.Format("{0} -o {1}", fileSettings.FileName, fileSettings.FileNameWithExeExtension)
            };

            using (Process process = new Process { StartInfo = processStartInfo })
            {
                process.Start();

                while (!process.StandardError.EndOfStream)
                {
                    processOutputInAList.Add(await process.StandardError.ReadLineAsync());
                }

                if (processOutputInAList.Count == 0)
                    return await StartCompiledProgram(fileSettings);

                process.WaitForExit();
            }

            foreach (var line in processOutputInAList)
            {
                processOutput.AppendLine(line);
            }

            return processOutput.ToString();
        }

        private async Task<string> StartCompiledProgram(IFileSettings fileSettings)
        {
            IList<string> processOutputInAList = new List<string>();
            StringBuilder processOutput = new StringBuilder();

            using (Process compiledProgram =
                new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = fileSettings.CompiledFilePath,
                        RedirectStandardOutput = true
                    }
                })
            {
                compiledProgram.Start();

                while (!compiledProgram.StandardOutput.EndOfStream)
                {
                    processOutputInAList.Add(await compiledProgram.StandardOutput.ReadLineAsync());
                }
            }

            foreach (var line in processOutputInAList)
            {
                processOutput.AppendLine(line);
            }

            return processOutput.ToString();
        }
    }
}
