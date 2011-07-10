using NUnit.Framework;

namespace Coticula.DTO.Tests
{
    [TestFixture]
    public class ResultTest
    {
        [Test]
        public void TestIdProperty()
        {
            const int id = 47;
            var result = new Result() { Id = id };
            Assert.AreEqual(id, result.Id);
        }

        [Test]
        public void TestVerdictIdProperty()
        {
            const int verdictId = 74;
            var result = new Result() { VerdictId = verdictId };
            Assert.AreEqual(verdictId, result.VerdictId);
        }

        [Test]
        public void TestSerialize()
        {
            const int id = 47;
            const int verdictId = 74;
            var result = new Result()
            {
                Id = id,
                VerdictId = verdictId
            };
            string json = Serializer.Serialize(result);
            const string expectedJson = "{\"Id\":47,\"VerdictId\":74}";
            Assert.AreEqual(expectedJson, json);
        }

        [Test]
        public void TestDeserialize()
        {
            const int id = 47;
            const int verdictId = 74;
            const string json = "{\"Id\":47,\"VerdictId\":74}";
            var result = Serializer.Deserialize<Result>(json);
            Assert.NotNull(result);
            Assert.AreEqual(id, result.Id);
            Assert.AreEqual(verdictId, result.VerdictId);
        }
    }
}
