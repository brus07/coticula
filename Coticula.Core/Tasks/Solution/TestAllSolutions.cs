
namespace Coticula.Core.Tasks.Solution
{
    class TestAllSolutions : ITask
    {
        public TestAllSolutions(IChannel channel)
        {
            _channel = channel;
        }

        public ITask[] Execute()
        {
            return new ITask[] { SolutionTaskCreator.CreateGetUntested(Channel) };
        }

        private readonly IChannel _channel;
        public IChannel Channel
        {
            get { return _channel; }
        }
    }
}
