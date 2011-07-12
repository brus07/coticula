using Coticula.DTO.Api;

namespace Coticula.Core.Tasks.Solution
{
    class GetUntested: ITask
    {
        public ITask[] Execute()
        {
            var coticulaApi = new CoticulaApi();
            var ids = coticulaApi.Untested();
            var tasks = new ITask[ids.Length];
            for (int i = 0; i < ids.Length; i++)
            {
                tasks[i] = SolutionTaskCreator.CreateGetSolution(ids[i]);
            }
            return tasks;
        }
    }
}
