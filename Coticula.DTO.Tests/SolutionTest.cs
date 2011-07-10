using NUnit.Framework;

namespace Coticula.DTO.Tests
{
    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void TestIdProperty()
        {
            const int id = 47;
            var sol = new Solution {Id = id};
            Assert.AreEqual(id,sol.Id);
        }

        [Test]
        public void TestAnswerProperty()
        {
            const string answer = "answer";
            var sol = new Solution { Answer = answer };
            Assert.AreEqual(answer, sol.Answer);
        }

        [Test]
        public void TestLanguageIdProperty()
        {
            const int languageId = 74;
            var sol = new Solution { LanguageId = languageId };
            Assert.AreEqual(languageId, sol.LanguageId);
        }

        [Test]
        public void TestSerialize()
        {
            const int id = 47;
            const string answer = "answer";
            const int languageId = 74;
            var sol = new Solution
                               {
                                   Id = id,
                                   Answer = answer,
                                   LanguageId = languageId
                               };
            string json = Serializer.Serialize(sol);
            const string expectedJson = "{\"Id\":47,\"Answer\":\"answer\",\"LanguageId\":74}";
            Assert.AreEqual(expectedJson, json);
        }

        [Test]
        public void TestDeserialize()
        {
            const int id = 47;
            const string answer = "answer";
            const int languageId = 74;
            const string json = "{\"Id\":47,\"Answer\":\"answer\",\"LanguageId\":74}";
            var sol = Serializer.Deserialize<Solution>(json);
            Assert.NotNull(sol);
            Assert.AreEqual(id,sol.Id);
            Assert.AreEqual(answer,sol.Answer);
            Assert.AreEqual(languageId, sol.LanguageId);
        }
    }
}
