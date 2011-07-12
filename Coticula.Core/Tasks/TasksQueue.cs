using System.Collections.Generic;
using Coticula.Core.Tasks.Solution;

namespace Coticula.Core.Tasks
{
    class TasksQueue: ITask
    {
        //private Queue<ITask> _queue = new Queue<ITask>();
        private Queue<ITask> Queue { get; set; }

        public TasksQueue()
        {
            Queue = new Queue<ITask>();
        }

        public ITask[] Execute()
        {
            Queue.Enqueue(SolutionTaskCreator.CreateTestAllSolutions());
            while (Queue.Count > 0)
            {
                ITask[] newTasks = Queue.Dequeue().Execute();
                foreach (var newTask in newTasks)
                {
                    Queue.Enqueue(newTask);
                }
            }
            return new ITask[0];
        }
    }
}
