using NUnit.Framework;

namespace Coticula.Core.Tests
{
    [TestFixture]
    public class TestCore
    {
        [Test]
        [Ignore]
        public void TestAllSolutions()
        {
            Core core = new Core();
            core.TestAllSolutions();
        }
    }
}
