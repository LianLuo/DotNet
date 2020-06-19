using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class BaseEntity
    {
        [Key]
        public int ID {get;set;}
        [Required]        
        public int CreatedBy { get; set; } = 1;
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public int LastUpdatedBy { get; set; } = 1;
        [Required]
        public DateTime LastUpdatedDate { get; set; }= DateTime.Now;
        [Required]
        public string TransactionId { get; set; } = string.Empty;
        [Required]
        public int VersionNo { get; set; } = 1;
    }
}