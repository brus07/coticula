
namespace Coticula.Web.Models
{
    public class Result
    {
        public int Id { get; set; }

        public virtual Verdict Verdict { get; set; }

        public virtual Solution Solution { get; set; }
    }
}