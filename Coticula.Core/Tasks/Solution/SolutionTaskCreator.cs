
namespace Coticula.Core.Tasks.Solution
{
    static class SolutionTaskCreator
    {
        public static TestAllSolutions CreateTestAllSolutions(IChannel channel)
        {
            return new TestAllSolutions(channel);
        }

        public static GetUntested CreateGetUntested(IChannel channel)
        {
            return new GetUntested(channel);
        }

        public static GetSolution CreateGetSolution(int id, IChannel channel)
        {
            return new GetSolution(id,channel);
        }

        public static TestSolution CreateTestSolution(DTO.Solution solution, IChannel channel)
        {
            return new TestSolution(solution, channel);
        }

        public static SendResult CreateSendResult(DTO.Result result, IChannel channel)
        {
            return new SendResult(result, channel);
        }
    }
}
