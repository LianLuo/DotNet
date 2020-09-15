using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class BaseEntity
    {
        [Key]
        public int ID { get; set; }
    }
}