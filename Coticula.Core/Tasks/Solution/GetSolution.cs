
namespace Coticula.Core.Tasks.Solution
{
    class GetSolution: ITask
    {
        private int Id { get; set; }
        public GetSolution(int id, IChannel channel)
        {
            Id = id;
            _channel = channel;
        }

        public ITask[] Execute()
        {
            var solution = Channel.Solution(Id);
            return new ITask[]{SolutionTaskCreator.CreateTestSolution(solution, Channel)};
        }

        private readonly IChannel _channel;
        public IChannel Channel
        {
            get { return _channel; }
        }
    }
}
