using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coticula.Core.Tasks
{
    static class TaskCreator
    {
        public static TasksQueue CreateTasksQueue()
        {
            return new TasksQueue();
        }
    }
}
