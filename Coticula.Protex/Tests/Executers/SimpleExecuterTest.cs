using System;
using System.IO;
using Coticula.Protex.Tests;
using NUnit.Framework;

namespace Coticula.Protex.Executers
{
    [TestFixture]
    public class SimpleExecuterTest
    {
        private string testDataFolder = Path.Combine(TestHelper.TestDataFolder, "Executers", "SimpleExecuter");

        [Test]
        public void F()
        {

            var simpleExecuter = new SimpleExecuter();
            var startInfo = new ExecuterStartInfo
                                {
                                    Command = Path.Combine(testDataFolder, "outabc.exe"),
                                    OutputStream = "a.out"
                                };
            startInfo.Command = "a.exe";
            startInfo.InputStream = "a.in";
            startInfo.ErrorStream = "a.err";
            startInfo.TimeLimit = 3800;
            startInfo.MemoryLimit = 2048*1024;
            simpleExecuter.Run(startInfo);
        }
    }
}
