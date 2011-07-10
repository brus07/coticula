using System.Web.Script.Serialization;

namespace Coticula.DTO
{
    public class Serializer
    {
        public static string Serialize(object ob)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(ob);
        }

        public static T Deserialize<T>(string s)
        {
            var serializer = new JavaScriptSerializer();
            var res = serializer.Deserialize<T>(s);
            return res;
        }
    }
}
