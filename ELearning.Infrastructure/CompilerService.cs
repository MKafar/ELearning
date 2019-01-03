using ELearning.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.IO;

namespace ELearning.Infrastructure
{
    public class CompilerService : ICompilerService
    {
        private const string AbsolutePathToCompilerExeFile = "CompilerAbsolutePath";
        private string _fileName;

        private readonly Process _compiler;
        
        public CompilerService()
        {
            var basePath = Directory.GetCurrentDirectory() + string.Format("{0}..{0}ELearning.WebUI", Path.DirectorySeparatorChar);
            
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.Local.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString(AbsolutePathToCompilerExeFile);

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException($"Absolute path to compiler exe file '{AbsolutePathToCompilerExeFile}' is null or empty.", nameof(connectionString));

            _compiler = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    WorkingDirectory = connectionString,
                    FileName = "g++.exe",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
        }

        public void SaveToFile(int assignmentId, string code)
        {
            var filePath = $"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}bin";

            DateTime now = DateTime.Now;
            var currentTime = $"{now.Hour}:{now.Minute}:{now.Second}:{now.Millisecond}";
            var currentDate = $"{now.Year}-{now.Month}-{now.Day}";

            _fileName = $"{assignmentId}_{currentDate}_{currentTime}.cpp";

           
        }

        public void Compile()
        {
            _compiler.StartInfo.Arguments = "command line arguments to your executable";

            _compiler.Start();
            while (!_compiler.StandardOutput.EndOfStream)
            {
                string line = _compiler.StandardOutput.ReadLine();
                // do something with line
            }
        }
    }
}
