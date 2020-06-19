using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class Commander : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
        
    }
}