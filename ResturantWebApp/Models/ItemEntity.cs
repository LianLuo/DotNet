using System.ComponentModel.DataAnnotations.Schema;

namespace ResturantWebApp.Models
{
    public class ItemEntity : BaseEntity
    {
        [Column(TypeName = "NVARCHAR(64)")]
        public string ItemName { get; set; }
        public decimal Price { get; set; }
    }
}