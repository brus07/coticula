using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Coticula.Web.Models
{
    public class Solution
    {
        public int Id { get; set; }

        [Required]
        public long Time { get; set; }

        [NotMapped]
        public DateTime DateTime
        {
            get { return DateTime.FromFileTimeUtc(Time).ToLocalTime(); }
            set { Time = value.ToFileTimeUtc(); }
        }

        [StringLength(65536)]
        public String Answer { get; set; }

        [Required]
        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public static int[] UntestedId()
        {
            var db = new CoticulaDbContext();
            var results = (from p in db.Results
                           where p.VerdictId == 1
                           select  p.Id ); 
            return results.ToArray();
        }

        [Required]
        public int ProblemId { get; set; }
        public Problem Problem { get; set; }
    }
}