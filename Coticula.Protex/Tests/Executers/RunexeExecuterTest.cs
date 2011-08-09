using System.IO;
using Coticula.Protex.Tests;
using NUnit.Framework;

namespace Coticula.Protex.Executers
{
    [TestFixture]
    public class RunexeExecuterTest
    {
        private readonly string _testDataFolder = Path.Combine(TestHelper.TestDataFolder, "Executers", "RunexeExecuter");

        [Test]
        public void TestSuccessRun()
        {

            for (int i = 0; i < 1; i++)
            {
                var simpleExecuter = new RunexeExecuter();
                var startInfo = new ExecuterStartInfo
                                    {
                                        Command = Path.Combine(_testDataFolder, "outabc.exe"),
                                    };
                Conclusion conclusion = simpleExecuter.Run(startInfo);
                Assert.AreEqual(ExecutionVerdict.Success, conclusion.ExecutionVerdict);
            }
        }

        [Test]
        public void TestMemoryLimitExceededRun()
        {
            var simpleExecuter = new RunexeExecuter();
            var startInfo = new ExecuterStartInfo
                                {
                                    Command = Path.Combine(_testDataFolder, "outabc.exe"),
                                    MemoryLimit = 1024 * 1024
                                };
            Conclusion conclusion = simpleExecuter.Run(startInfo);
            Assert.AreEqual(ExecutionVerdict.MemoryLimitExceeded, conclusion.ExecutionVerdict);
        }

        [Test]
        public void TestTimeLimitExceededRun()
        {
            var simpleExecuter = new RunexeExecuter();
            var startInfo = new ExecuterStartInfo
            {
                Command = Path.Combine(_testDataFolder, "timeLimit3secs.exe"),
                TimeLimit = 2000
            };
            Conclusion conclusion = simpleExecuter.Run(startInfo);
            Assert.AreEqual(ExecutionVerdict.TimeLimitExceeded, conclusion.ExecutionVerdict);
        }

        [Test]
        public void TestTimeLimitExceededWithWaitInputRun()
        {
            var simpleExecuter = new RunexeExecuter();
            var startInfo = new ExecuterStartInfo
            {
                Command = Path.Combine(_testDataFolder, "timeLimitWithWaitInput.exe")
            };
            Conclusion conclusion = simpleExecuter.Run(startInfo);
            Assert.AreEqual(ExecutionVerdict.RuntimeError, conclusion.ExecutionVerdict);
            Assert.AreEqual(6, conclusion.ReturnCode);
        }

        [Test]
        public void TestWithInputRun()
        {
            var simpleExecuter = new RunexeExecuter();
            var startInfo = new ExecuterStartInfo
                                {
                                    Command = Path.Combine(_testDataFolder, "Long3sec", "longwithread.exe"),
                                    WorkingDirectory = Path.Combine(_testDataFolder, "Long3sec"),
                                    InputStream = "longwithread.in"
                                };
            Conclusion conclusion = simpleExecuter.Run(startInfo);
            Assert.AreEqual(ExecutionVerdict.Success, conclusion.ExecutionVerdict);
        }

        [Test]
        public void TestWithOutputRun()
        {
            var simpleExecuter = new RunexeExecuter();
            var startInfo = new ExecuterStartInfo
            {
                Command = Path.Combine(_testDataFolder, "outabc.exe"),
                OutputStream = "outabcexe.out",
            };
            Conclusion conclusion = simpleExecuter.Run(startInfo);
            Assert.AreEqual(ExecutionVerdict.Success, conclusion.ExecutionVerdict);
            
            Assert.True(File.Exists(startInfo.OutputStream));

            string outputString = File.ReadAllText(startInfo.OutputStream);

            Assert.AreEqual("abc", outputString);

            if (File.Exists(startInfo.OutputStream))
                File.Delete(startInfo.OutputStream);
        }

        [Test]
        public void TestWithErrorRun()
        {
            var simpleExecuter = new RunexeExecuter();
            var startInfo = new ExecuterStartInfo
            {
                Command = Path.Combine(_testDataFolder, "timeLimitWithWaitInput.exe"),
                ErrorStream = "outabcexe.err",
            };
            Conclusion conclusion = simpleExecuter.Run(startInfo);
            Assert.AreEqual(ExecutionVerdict.RuntimeError, conclusion.ExecutionVerdict);
            Assert.AreEqual(6, conclusion.ReturnCode);

            Assert.True(File.Exists(startInfo.ErrorStream));

            string errorString = File.ReadAllText(startInfo.ErrorStream);

            Assert.AreEqual("abc", errorString);

            if (File.Exists(startInfo.ErrorStream))
                File.Delete(startInfo.ErrorStream);
        }
    }
}