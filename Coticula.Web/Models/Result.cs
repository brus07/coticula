
namespace Coticula.Web.Models
{
    public class Result
    {
        public Result()
        {
            VerdictId = 1;
        }

        public int Id { get; set; }

        public int VerdictId { get; set; }
        public virtual Verdict Verdict { get; set; }

        public virtual Solution Solution { get; set; }
    }
}