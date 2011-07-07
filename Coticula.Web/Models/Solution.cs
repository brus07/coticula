using System;
using System.ComponentModel.DataAnnotations;

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

        [StringLength(65000)]
        public String Answer { get; set; }

        [Required]
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}