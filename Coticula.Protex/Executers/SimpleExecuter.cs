using System;
using System.Diagnostics;
using System.IO;
using Coticula.Protex.Executers.runexe;

namespace Coticula.Protex.Executers
{
    internal class SimpleExecuter : IExecuter
    {
        private Process _process;

        private readonly string _pathToRunExe = Path.Combine("Tools", "runexe", "runexe.exe");

        public Conclusion Run(ExecuterStartInfo executerStartInfo)
        {
            //paranoidal checks
            if (string.IsNullOrEmpty(executerStartInfo.InputStream) == false)
            {
                var inputFileFullPath = executerStartInfo.InputStream;
                if (string.IsNullOrEmpty(executerStartInfo.WorkingDirectory) == false)
                    inputFileFullPath = Path.Combine(executerStartInfo.WorkingDirectory, executerStartInfo.InputStream);
                if (!File.Exists(inputFileFullPath))
                    throw new FileNotFoundException(string.Format("File \"{0}\" is missing.", inputFileFullPath));
            }

            //runexe.exe -i a.in -t 3500ms -m 2048K -xml a.exe
            string options = "";
            //set input file
            if (string.IsNullOrEmpty(executerStartInfo.InputStream) == false)
            {
                options += " -i " + executerStartInfo.InputStream;
            }
            //set output file
            if (string.IsNullOrEmpty(executerStartInfo.OutputStream) == false)
            {
                options += " -o " + executerStartInfo.OutputStream;
            }
            //set error file
            if (string.IsNullOrEmpty(executerStartInfo.ErrorStream) == false)
            {
                options += " -e " + executerStartInfo.ErrorStream;
            }

            //set time limit
            if (executerStartInfo.TimeLimit > 0)
            {
                options += string.Format(" -t {0}ms", executerStartInfo.TimeLimit);
            }

            //set memory limit
            if (executerStartInfo.MemoryLimit > 0)
            {
                options += string.Format(" -m {0}K", executerStartInfo.MemoryLimit/1024);
            }

            //set working directory
            if (string.IsNullOrEmpty(executerStartInfo.WorkingDirectory) == false)
            {
                options += " -d " + executerStartInfo.WorkingDirectory;
            }

            //result of runexe in XML format
            options += " -xml";
            
            var startInfo = new ProcessStartInfo
                                {
                                    UseShellExecute = false,
                                    ErrorDialog = false,
                                    CreateNoWindow = true,
                                    FileName = _pathToRunExe,
                                    RedirectStandardOutput = true,
                                    Arguments = string.Format("{0} {1}", options, executerStartInfo.Command),
                                };

            Console.WriteLine(string.Format("Run \"{0} {1}\".", startInfo.FileName,
                                            startInfo.Arguments));

            _process = new Process { StartInfo = startInfo };

            Conclusion conclusion = new Conclusion();

            try
            {
                _process.Start();

                var stdoutReader = _process.StandardOutput;

                // implementation of TimeLimit: wait for process
                // only some time, than kill it
                var milliseconds = (int)executerStartInfo.TimeLimit*2;
                _process.WaitForExit(milliseconds);

                // kill the process after waiting
                if (!_process.HasExited)
                {
                    try
                    {
                        _process.Kill();
                    }
                    catch
                    {
                    }

                    // after kill return time limit
                    //return this.SetResult(Verdict.TL, "Time limit occured");

                    conclusion.UsedTime = _process.UserProcessorTime.Ticks;

                    throw new NotImplementedException("to long");
                }

                string xml = stdoutReader.ReadToEnd();
                InvocationResult invocationResult = InvocationResult.DeserializeFromXml(xml);
                Console.WriteLine(xml);

                conclusion.UsedMemory = invocationResult.ConsumedMemory;
                conclusion.ReturnCode = invocationResult.ExitCode;
                conclusion.UsedTime = invocationResult.ProcessorKernelModeTime + invocationResult.ProcessorUserModeTime;
            }
            catch (Exception exception)
            {

                throw;
            }

            return conclusion;
        }
    }
}
