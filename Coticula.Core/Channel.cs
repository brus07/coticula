using System;
using Coticula.DTO;

namespace Coticula.Core
{
    public abstract class Channel: IChannel
    {
        public event UntestedEventHandler UntestedEvent;
        public virtual int[] Untested()
        {
            var untestedEvent = UntestedEvent;
            if (untestedEvent != null)
            {
                return untestedEvent();
            }
            throw new NotImplementedException();
        }

        public event SolutionEventHandler SolutionEvent;
        public virtual Solution Solution(int id)
        {
            var solutionEvent = SolutionEvent;
            if (solutionEvent != null)
            {
                return solutionEvent(id);
            }
            throw new NotImplementedException();
        }

        public event ResultEventHandler ResultEvent;
        public virtual bool Result(Result result)
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
