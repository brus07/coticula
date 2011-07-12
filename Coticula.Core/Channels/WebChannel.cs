using Coticula.DTO.Api;

namespace Coticula.Core.Channels
{
    internal class WebChannel : Channel
    {
        private readonly CoticulaApi _coticulaApi = new CoticulaApi();

        public WebChannel()
        {
            UntestedEvent += _coticulaApi.Untested;
            SolutionEvent += _coticulaApi.Solution;
            ResultEvent += _coticulaApi.Result;
        }
    }
}
