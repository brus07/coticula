using System;
using System.ComponentModel.DataAnnotations;

namespace Coticula.Web.Models
{
    public class Solution
    {
        public int Id { get; set; }

        public virtual Result Result { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [StringLength(65000)]
        public String Answer { get; set; }

        [Required]
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
    }
}