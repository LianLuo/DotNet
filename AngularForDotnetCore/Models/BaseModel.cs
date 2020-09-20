using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularForDotnetCore.Models
{
    public class BaseModel
    {
        [Key]
        public int ID { get; set; }
        public int CreatedBy { get; set; } = 1;
        public int LastUpdatedBy { get; set; } = 1;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastUpdatedDate { get; set; } = DateTime.Now;
        public string Transaction { get; set; } = string.Empty;
        public int VersionNo { get; set; } = 1;
    }
}
