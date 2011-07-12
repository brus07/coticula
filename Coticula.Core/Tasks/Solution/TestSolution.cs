using Coticula.DTO;

namespace Coticula.Core.Tasks.Solution
{
    class TestSolution: ITask
    {
        private DTO.Solution Solution { get; set; }

        public TestSolution(DTO.Solution solution)
        {
            Solution = solution;
        }

        public ITask[] Execute()
        {
            Result result = new Result
                                    {
                                        Id = Solution.Id,
                                        VerdictId = 2
                                    };
            return new ITask[]{SolutionTaskCreator.CreateSendResult(result)};
        }
    }
}
