using System.ComponentModel.DataAnnotations.Schema;

namespace ResturantWebApp.Models
{
    public class OrderEntity : BaseEntity
    {
        [Column(TypeName = "NVARCHAR(32)")]
        public string OrderNumber { get; set; }
        public int CustomerID { get; set; }
        public int PaymentID { get; set; }
        public decimal Total { get; set; }
    }
}