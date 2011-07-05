using System.ComponentModel.DataAnnotations;

namespace Coticula.Web.Models
{
    public class Verdict
    {
        public int Id { get; set; }

        [Required, StringLength(32)]
        public string Name { get; set; }
    }
}