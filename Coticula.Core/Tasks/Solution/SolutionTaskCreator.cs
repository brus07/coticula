
namespace Coticula.Core.Tasks.Solution
{
    static class SolutionTaskCreator
    {
        public static TestAllSolutions CreateTestAllSolutions()
        {
            return new TestAllSolutions();
        }

        public static GetUntested CreateGetUntested()
        {
            return new GetUntested();
        }

        public static GetSolution CreateGetSolution(int id)
        {
            return new GetSolution(id);
        }

        public static TestSolution CreateTestSolution(DTO.Solution solution)
        {
            return new TestSolution(solution);
        }

        public static SendResult CreateSendResult(DTO.Result result)
        {
            return new SendResult(result);
        }
    }
}
