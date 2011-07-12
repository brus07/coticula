using System;
using Coticula.DTO.Api;

namespace Coticula.Core.Tasks.Solution
{
    class GetSolution: ITask
    {
        private int Id { get; set; }
        public GetSolution(int id)
        {
            Id = id;
        }

        public ITask[] Execute()
        {
            var coticulaApi = new CoticulaApi();
            var solution = coticulaApi.Solution(Id);
            return new ITask[]{SolutionTaskCreator.CreateTestSolution(solution)};
        }
    }
}
