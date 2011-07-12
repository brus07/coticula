using Coticula.DTO.Api;

namespace Coticula.Core.Tasks.Solution
{
    class SendResult: ITask
    {
        private DTO.Result Result { get; set; }

        public SendResult(DTO.Result result)
        {
            Result = result;
        }

        public ITask[] Execute()
        {
            var coticulaApi = new CoticulaApi();
            coticulaApi.Result(Result);
            return new ITask[0];
        }
    }
}
