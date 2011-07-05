using System;
using System.ComponentModel.DataAnnotations;

namespace Coticula.Web.Models
{
    public sealed class Solution
    {
        public Solution()
        {
            Result = new Result();
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
                Result.Id = Id;
            }
        }

        public Result Result { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [StringLength(65000)]
        public String Answer { get; set; }

        [Required]
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}