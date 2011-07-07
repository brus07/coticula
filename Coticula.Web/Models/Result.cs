
using System.ComponentModel.DataAnnotations;

namespace Coticula.Web.Models
{
    public sealed class Result
    {
        public Result()
        {
            VerdictId = 1;
            Solution = new Solution();
        }

        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                Solution.Id = Id;
            }
        }

        public int VerdictId { get; set; }
        public Verdict Verdict { get; set; }

        [Required]
        public Solution Solution { get; set; }
    }
}