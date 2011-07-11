using System;

namespace Coticula.DTO.Api
{
    public class CoticulaApiException: Exception
    {
        public string Type { get; set; }

        public CoticulaApiException(string type, string msg)
            : base(msg)
        {
            Type = type;
        }

        public override string ToString()
        {
            return Type + ": " + base.ToString();
        }

        public CoticulaApiException()
        { }
    }
}
