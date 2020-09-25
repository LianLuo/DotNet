using System.ComponentModel.DataAnnotations.Schema;

namespace ResturantWebApp.Models
{
    public class PaymentEntity : BaseEntity
    {
        [Column(TypeName = "NVARCHAR(128)")]
        public string PayMethod { get; set; }

        [Column(TypeName = "NVARCHAR(256)")]
        public string CompanyName { get; set; }
    }
}