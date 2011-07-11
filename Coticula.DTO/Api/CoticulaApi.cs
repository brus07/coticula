
namespace Coticula.DTO.Api
{
    public class CoticulaApi
    {
        private readonly JsonWebClient _webClient = new JsonWebClient(@"http://localhost:52974/");

        public int[] Untested()
        {
            string response = _webClient.Get(string.Format("/Api/Untested.json"));
            var untested = Serializer.Deserialize<int[]>(response);
            return untested;
        }

        public Solution Solution(int id)
        {
            string response = _webClient.Get(string.Format("/Api/Solution/{0}.json", id));
            var solution = Serializer.Deserialize<Solution>(response);
            return solution;
        }

        public bool Result(Result result)
        {
            var json = Serializer.Serialize(result);
            _webClient.Post("/Api/Result.json", json);
            return true;
        }
    }
}
