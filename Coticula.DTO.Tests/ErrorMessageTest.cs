using NUnit.Framework;

namespace Coticula.DTO.Tests
{
    [TestFixture]
    public class ErrorMessageTest
    {
        [Test]
        public void TestMessageProperty()
        {
            const string message = "error message";
            var error = new ErrorMessage.ConctreteError {Message = message};
            Assert.AreEqual(message, error.Message);
        }

        [Test]
        public void TestTypeProperty()
        {
            const string type = "fatal";
            var error = new ErrorMessage.ConctreteError {Type = type};
            Assert.AreEqual(type, error.Type);
        }

        [Test]
        public void TestErrorProperty()
        {
            const string type = "fatal";
            const string message = "error message";
            var errorMessage = new ErrorMessage {Error = new ErrorMessage.ConctreteError { Type = type, Message = message }};
            Assert.NotNull(errorMessage.Error);
            Assert.AreEqual(type, errorMessage.Error.Type);
            Assert.AreEqual(message, errorMessage.Error.Message);
        }

        [Test]
        public void TestSerialize()
        {
            const string type = "fatal";
            const string message = "error message";
            var error = new ErrorMessage{ Error = new ErrorMessage.ConctreteError { Type = type, Message = message } };
            string json = Serializer.Serialize(error);
            const string expectedJson = "{\"Error\":{\"Type\":\"fatal\",\"Message\":\"error message\"}}";
            Assert.AreEqual(expectedJson, json);
        }

        [Test]
        public void TestDeserialize()
        {
            const string type = "fatal";
            const string message = "error message";
            const string json = "{\"Error\":{\"Type\":\""+type+"\",\"Message\":\""+message+"\"}}";
            var errorMessage = Serializer.Deserialize<ErrorMessage>(json);
            Assert.NotNull(errorMessage);
            Assert.NotNull(errorMessage.Error);
            Assert.AreEqual(type, errorMessage.Error.Type);
            Assert.AreEqual(message, errorMessage.Error.Message);
        }
    }
}
