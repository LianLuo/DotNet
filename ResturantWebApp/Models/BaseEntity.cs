using System;
using System.ComponentModel.DataAnnotations;

namespace ResturantWebApp.Models
{
    public class BaseEntity
    {
        [Key]
        public int ID { get; set; }
        public int CreatedBy { get; set; } = 1;
        public int LastUpdatedBy { get; set; } = 1;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastUpdatedDate { get; set; } = DateTime.Now;
        public int VersionNo { get; set; } = 1;
        public bool IsDeleted { get; set; } = false;
        public string Transaction { get; set; } = string.Empty;
    }
}