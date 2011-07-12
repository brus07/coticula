using System;
using Coticula.DTO;
using Coticula.DTO.Api;

namespace Coticula.Core.Channels
{
    internal class WebChannel: IChannel
    {
        private readonly CoticulaApi _coticulaApi = new CoticulaApi();

        public WebChannel()
        {
            UntestedEvent += _coticulaApi.Untested;
            SolutionEvent += _coticulaApi.Solution;
            ResultEvent += _coticulaApi.Result;
        }

        public event UntestedEventHandler UntestedEvent;
        public int[] Untested()
        {
            var untestedEvent = UntestedEvent;
            if (untestedEvent != null)
            {
                return untestedEvent();
            }
            throw new NotImplementedException();
        }

        public event SolutionEventHandler SolutionEvent;
        public Solution Solution(int id)
        {
            var solutionEvent = SolutionEvent;
            if (solutionEvent != null)
            {
                return solutionEvent(id);
            }
            throw new NotImplementedException();
        }

        public event ResultEventHandler ResultEvent;
        public bool Result(Result result)
        {
            var resultEvent = ResultEvent;
            if (resultEvent != null)
            {
                return resultEvent(result);
            }
            throw new NotImplementedException();
        }
    }
}
