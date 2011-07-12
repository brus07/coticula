using System;
using Coticula.Core.Tasks;

namespace Coticula.Core
{
    public class Core
    {
        public void TestAllSolutions()
        {
            ITask task = TaskCreator.CreateTasksQueue();
            task.Execute();
        }
    }
}
