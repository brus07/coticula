using Coticula.DTO;
using NUnit.Framework;

namespace Coticula.Core.Tests
{
    [TestFixture]
    public class TestCore
    {
        [Test]
        [Ignore]
        public void TestAllSolutionsWithDefaultChannel()
        {
            var core = new Core();
            core.TestAllSolutions();
        }

        
        class LocalChannel: Channel
        {
        }

        [Test]
        public void TestAllSolutions()
        {
            var core = new Core();
            var channel = new LocalChannel();
            core.Channel = channel;

            int[] assertLogic = {0};

            channel.UntestedEvent += delegate
                                         {
                                             Assert.AreEqual(0, assertLogic[0]);
                                             assertLogic[0]++;
                                             return new[] {1, 2};
                                         };
            channel.SolutionEvent += delegate(int id)
                                         {
                                             if (assertLogic[0] == 1)
                                                 Assert.AreEqual(1, id);
                                             if (assertLogic[0] == 2)
                                                 Assert.AreEqual(2, id);
                                             assertLogic[0]++;
                                             return new Solution {Id = id, Answer = "gogog", LanguageId = 1};
                                         };
            channel.ResultEvent += delegate(Result result)
                                       {
                                           if (assertLogic[0] == 3)
                                               Assert.AreEqual(1, result.Id);
                                           if (assertLogic[0] == 4)
                                               Assert.AreEqual(2, result.Id);
                                           assertLogic[0]++;
                                           return true;
                                       };

            core.TestAllSolutions();

            Assert.AreEqual(5, assertLogic[0]);
        }
    }
}
