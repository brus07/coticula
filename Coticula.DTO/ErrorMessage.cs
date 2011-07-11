
namespace Coticula.DTO
{
    public class ErrorMessage
    {
        public class ConctreteError
        {
            public string Type { get; set; }
            public string Message { get; set; }
        }

        public ConctreteError Error { get; set; }
    }
}
