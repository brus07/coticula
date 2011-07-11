using System;
using System.IO;
using System.Net;
using System.Text;

namespace Coticula.DTO.Api
{
    internal enum HttpVerb
    {
        GET,
        POST,
        DELETE
    }

    /// <summary>
    /// Wrapper around the API. 
    /// </summary>
    internal class JsonWebClient
    {
        private Uri Host { get; set; }

        public JsonWebClient(string host)
        {
            Host = new Uri(host);
        }

        /// <summary>
        /// Makes a GET request.
        /// </summary>
        /// <param name="relativePath">The path for the call,
        /// e.g. /username</param>
        public string Get(string relativePath)
        {
            return Call(relativePath, HttpVerb.GET);
        }

        /// <summary>
        /// Makes a POST request.
        /// </summary>
        /// <param name="relativePath">The path for the call,
        /// e.g. /username</param>
        /// <param name="argument">String thar represents the request data, must be in JSON format</param>
        public string Post(string relativePath, string argument = null)
        {
            return Call(relativePath, HttpVerb.POST, argument);
        }

        /// <summary>
        /// Makes a Call.
        /// </summary>
        /// <param name="relativePath">The path for the call, 
        /// e.g. /username</param>
        /// <param name="httpVerb">The HTTP verb to use, e.g.
        /// GET, POST, DELETE</param>
        /// <param name="argument">String thar represents the request data, must be in JSON format</param>
        private string Call(string relativePath, HttpVerb httpVerb, string argument = null)
        {
            var url = new Uri(Host, relativePath);

            var response = MakeRequest(url, httpVerb, argument);
            {
                ErrorMessage errorMessage = null;
                try
                {
                    errorMessage = Serializer.Deserialize<ErrorMessage>(response);
                }
                catch
                {
                }
                if (errorMessage != null)
                    if (errorMessage.Error != null)
                        throw new CoticulaApiException(errorMessage.Error.Type, errorMessage.Error.Message);
            }
            return response;
        }

        /// <summary>
        /// Make an HTTP request, with the given query args
        /// </summary>
        /// <param name="url">The URL of the request</param>
        /// <param name="httpVerb">The HTTP verb to use</param>
        /// <param name="argument">String thar represents the request data, must be in JSON format</param>
        private static string MakeRequest(Uri url, HttpVerb httpVerb, string argument = null)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = httpVerb.ToString();
            request.ContentType = "application/json";

            if (httpVerb == HttpVerb.POST)
            {
                var encoding = new ASCIIEncoding();
                var postDataBytes = new byte[0];
                if (argument != null)
                {
                    postDataBytes = encoding.GetBytes(argument);
                }

                request.ContentLength = postDataBytes.Length;

                var requestStream = request.GetRequestStream();
                requestStream.Write(postDataBytes, 0, postDataBytes.Length);
                requestStream.Close();
            }

            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    var reader = new StreamReader(response.GetResponseStream());
                    return reader.ReadToEnd();
                }
            }
            catch (WebException e)
            {
                throw new CoticulaApiException("Server Error", e.Message);
            }
        }
    }
}
