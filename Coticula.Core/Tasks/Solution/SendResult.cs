
namespace Coticula.Core.Tasks.Solution
{
    class SendResult: ITask
    {
        private DTO.Result Result { get; set; }

        public SendResult(DTO.Result result, IChannel channel)
        {
            Result = result;
            _channel = channel;
        }

        public ITask[] Execute()
        {
            Channel.Result(Result);
            return new ITask[0];
        }

        private readonly IChannel _channel;
        public IChannel Channel
        {
            get { return _channel; }
        }
    }
}
