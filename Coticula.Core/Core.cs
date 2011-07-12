using Coticula.Core.Channels;
using Coticula.Core.Tasks;

namespace Coticula.Core
{
    public class Core
    {
        private IChannel _channel;
        public IChannel Channel
        {
            get
            {
                return _channel ?? (_channel = new WebChannel());
            }
            set
            {
                _channel = value;
            }
        }

        public void TestAllSolutions()
        {
            ITask task = TaskCreator.CreateTasksQueue(Channel);
            task.Execute();
        }
    }
}
