
namespace Coticula.Core.Tasks.Solution
{
    class TestAllSolutions : ITask
    {
        public ITask[] Execute()
        {
            return new ITask[] { SolutionTaskCreator.CreateGetUntested() };
        }
    }
}
