
namespace Coticula.Core.Tasks
{
    static class TaskCreator
    {
        public static TasksQueue CreateTasksQueue(IChannel channel)
        {
            return new TasksQueue(channel);
        }
    }
}
