using Coticula.DTO.Api;
using NUnit.Framework;

namespace Coticula.DTO.Tests.Api
{
    [TestFixture]
    [Ignore]
    public class CoticulaApiTest
    {
        [Test]
        public void TestUntested()
        {
            var coticulaApi = new CoticulaApi();
            var ids = coticulaApi.Untested();
            foreach (var id in ids)
            {
                var solution = coticulaApi.Solution(id);
                var result = new Result { Id = solution.Id, VerdictId = 2 };
                coticulaApi.Result(result);
            }
        }

        [Test]
        public void TestSolutionApi()
        {
            const int id = 1;
            var coticulaApi = new CoticulaApi();
            var solution = coticulaApi.Solution(id);
            Assert.NotNull(solution);
            Assert.AreEqual(id, solution.Id);
        }

        [Test]
        public void TestResultApi()
        {
            const int id = 2;
            const int verdictId = 1;
            var result = new Result { Id = id, VerdictId = verdictId };
            var coticulaApi = new CoticulaApi();
            coticulaApi.Result(result);
        }
    }
}
