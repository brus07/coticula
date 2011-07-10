using System.Collections;
using NUnit.Framework;

namespace Coticula.DTO.Tests
{
    [TestFixture]
    public class SerializerTest
    {
        [Test]
        public void TestSerialize()
        {
            var arrayList = new ArrayList {1, 2, 3};
            var json = Serializer.Serialize(arrayList);
            Assert.AreEqual("[1,2,3]", json);
        }

        [Test]
        public void TestDeserialize()
        {
            const string json = "[1,2,3]";
            var arrayList = Serializer.Deserialize<ArrayList>(json);
            Assert.AreEqual(3, arrayList.Count);
            Assert.AreEqual(1, arrayList[0]);
            Assert.AreEqual(2, arrayList[1]);
            Assert.AreEqual(3, arrayList[2]);
        }

        [Test]
        public void TestSerializeWithNull()
        {
            var json = Serializer.Serialize(null);
            Assert.AreEqual("null", json);
        }

        [Test]
        public void TestDeserializeWithNull()
        {
            const string json = "null";
            var arrayList = Serializer.Deserialize<ArrayList>(json);
            Assert.AreEqual(null, arrayList);
        }
    }
}
