using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class Command : BaseEntity
    {
        [Required]
        [MaxLength(256)]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}