using System.Web.Mvc;
using Coticula.DTO;

namespace Coticula.Web.Helpers
{
    /// <summary>
    /// An action result that renders the given object using JSON to the response stream.
    /// </summary>
    public class RenderJsonResult : ActionResult
    {
        /// <summary>
        /// The result object to render using JSON.
        /// </summary>
        public object Result { private get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.Output.Write(Serializer.Serialize(Result));
        }
    }
}