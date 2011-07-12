
namespace Coticula.Core.Tasks.Solution
{
    class GetUntested: ITask
    {
        public GetUntested(IChannel channel)
        {
            _channel = channel;
        }

        public ITask[] Execute()
        {
            var ids = Channel.Untested();
            var tasks = new ITask[ids.Length];
            for (int i = 0; i < ids.Length; i++)
            {
                tasks[i] = SolutionTaskCreator.CreateGetSolution(ids[i], Channel);
            }
            return tasks;
        }

        private readonly IChannel _channel;
        public IChannel Channel
        {
            get { return _channel; }
        }
    }
}
