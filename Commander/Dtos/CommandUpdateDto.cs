using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class CommandUpdateDto
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