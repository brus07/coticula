using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Coticula.Protex.Executers.runexe;

namespace Coticula.Protex.Executers
{
    internal class RunexeExecuter : IExecuter
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

            if (executerStartInfo.WorkingDirectory == null)
                executerStartInfo.WorkingDirectory = "";

            //set input file
            if (string.IsNullOrEmpty(executerStartInfo.InputStream) == false)
            {
                options += string.Format(" -i \"{0}\"", Path.Combine(executerStartInfo.WorkingDirectory, executerStartInfo.InputStream));
            }

            //set output file
            string temporaryOutputFile = null;
            string temporaryDirectory = Path.Combine(Path.GetTempPath(), Assembly.GetExecutingAssembly().GetName().Name);
            if (string.IsNullOrEmpty(executerStartInfo.OutputStream) == false)
            {
                options += string.Format(" -o \"{0}\"", Path.Combine(executerStartInfo.WorkingDirectory, executerStartInfo.OutputStream));
            }
            else
            {
                temporaryOutputFile = Path.Combine(temporaryDirectory, Path.GetRandomFileName());
                Directory.CreateDirectory(temporaryDirectory);
                options += string.Format(" -o \"{0}\"", temporaryOutputFile);
            }

            //set error file
            string temporaryErrorFile = null;
            if (string.IsNullOrEmpty(executerStartInfo.ErrorStream) == false)
            {
                options += string.Format(" -e \"{0}\"", Path.Combine(executerStartInfo.WorkingDirectory, executerStartInfo.ErrorStream));
            }
            else
            {
                temporaryErrorFile = Path.Combine(temporaryDirectory, Path.GetRandomFileName());
                Directory.CreateDirectory(temporaryDirectory);
                options += string.Format(" -e \"{0}\"", temporaryErrorFile);
            }

            //set time limit
            if (executerStartInfo.TimeLimit > 0)
            {
                options += string.Format(" -t {0}ms", executerStartInfo.TimeLimit);
            }

            //set memory limit
            if (executerStartInfo.MemoryLimit > 0)
            {
                options += string.Format(" -m {0}K", executerStartInfo.MemoryLimit / 1024);
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

                if (executerStartInfo.TimeLimit != 0)
                {
                    // implementation of TimeLimit: wait for process
                    // only some time, than kill it
                    var milliseconds = (int)executerStartInfo.TimeLimit * 2;
                    _process.WaitForExit(milliseconds);

                    // kill the process after waiting
                    if (!_process.HasExited)
                    {
                        try
                        {
                            _process.Kill();
                        }
                        catch (Exception)
                        {
                            throw;
                        }

                        // after kill return time limit
                        //return this.SetResult(Verdict.TL, "Time limit occured");

                        conclusion.ExecutionVerdict = ExecutionVerdict.TimeLimitExceeded;

                        if (string.IsNullOrEmpty(temporaryOutputFile)==false)
                        {
                            File.Delete(temporaryOutputFile);
                        }
                        if (string.IsNullOrEmpty(temporaryErrorFile) == false)
                        {
                            File.Delete(temporaryErrorFile);
                        }

                        return conclusion;
                    }
                }

                string xml = stdoutReader.ReadToEnd();
                //Console.WriteLine(xml);
                InvocationResult invocationResult = InvocationResult.DeserializeFromXml(xml);

                switch (invocationResult.InvocationVerdict)
                {
                    case "SUCCESS":
                        conclusion.ExecutionVerdict = ExecutionVerdict.Success;
                        conclusion.UsedMemory = invocationResult.ConsumedMemory;
                        conclusion.UsedTime = invocationResult.ProcessorKernelModeTime +
                                              invocationResult.ProcessorUserModeTime;
                        break;
                    case "IDLENESS_LIMIT_EXCEEDED":
                    case "TIME_LIMIT_EXCEEDED":
                        conclusion.ExecutionVerdict = ExecutionVerdict.TimeLimitExceeded;
                        break;
                    case "MEMORY_LIMIT_EXCEEDED":
                        conclusion.ExecutionVerdict = ExecutionVerdict.MemoryLimitExceeded;
                        break;
                    default:
                        throw new InvalidOperationException(string.Format("InvocationVerdict \"{0}\" from runexe does not understand.", invocationResult.InvocationVerdict));
                }

                conclusion.ReturnCode = invocationResult.ExitCode;
                if (invocationResult.ExitCode != 0)
                    conclusion.ExecutionVerdict = ExecutionVerdict.RuntimeError;
            }
            catch (Exception exception)
            {

                throw;
            }

            if (string.IsNullOrEmpty(temporaryOutputFile) == false && File.Exists(temporaryOutputFile))
            {
                File.Delete(temporaryOutputFile);
            }
            if (string.IsNullOrEmpty(temporaryErrorFile) == false && File.Exists(temporaryErrorFile))
            {
                File.Delete(temporaryErrorFile);
            }

            return conclusion;
        }
    }
}
