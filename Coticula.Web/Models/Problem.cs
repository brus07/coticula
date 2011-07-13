using System.ComponentModel.DataAnnotations;

namespace Coticula.Web.Models
{
    public class Problem
    {
        public int Id { get; set; }

        [Required, StringLength(32)]
        public string Name { get; set; }

        [StringLength(65536)]
        public string Description { get; set; }
    }
}