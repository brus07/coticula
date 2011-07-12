using Coticula.DTO;

namespace Coticula.Core.Tasks.Solution
{
    class TestSolution: ITask
    {
        private DTO.Solution Solution { get; set; }

        public TestSolution(DTO.Solution solution, IChannel channel)
        {
            Solution = solution;
            _channel = channel;
        }

        public ITask[] Execute()
        {
            //TODO:
            var result = new Result
                                    {
                                        Id = Solution.Id,
                                        VerdictId = 2
                                    };
            return new ITask[] { SolutionTaskCreator.CreateSendResult(result, Channel) };
        }

        private readonly IChannel _channel;
        public IChannel Channel
        {
            get { return _channel; }
        }
    }
}
