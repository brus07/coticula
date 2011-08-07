using NUnit.Framework;

namespace Coticula.Protex.Tests
{
    [TestFixture]
    public class DemoTest
    {
        [Test]
        [Ignore]
        public void TestSimpleExecuterWithPrimitiveRun()
        {
            IExecuter executer = ExecuterCreator.CreateRunexeExecuter();
            ExecuterStartInfo executerStartInfo = ExecuterStartInfo.CreateInstance();
            Conclusion conclusion = executer.Run(executerStartInfo);
        }
    }
}
