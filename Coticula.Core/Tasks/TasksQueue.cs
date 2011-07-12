using System.Collections.Generic;
using Coticula.Core.Tasks.Solution;

namespace Coticula.Core.Tasks
{
    class TasksQueue: ITask
    {
        private Queue<ITask> Queue { get; set; }

        public TasksQueue(IChannel channel)
        {
            Queue = new Queue<ITask>();
            _channel = channel;
        }

        public ITask[] Execute()
        {
            Queue.Enqueue(SolutionTaskCreator.CreateTestAllSolutions(Channel));
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

        private readonly IChannel _channel;
        public IChannel Channel
        {
            get { return _channel; }
        }
    }
}
