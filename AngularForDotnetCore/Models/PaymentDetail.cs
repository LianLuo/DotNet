using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularForDotnetCore.Models
{
    public class PaymentDetail
    {
        [Key]
        public int EMPID { get; set; }
        [Column(TypeName="VARCHAR(64)")]
        public string CardOwnerName { get; set; }
        [Column(TypeName="VARCHAR(16)")]
        public string CardNumber { get; set; }
        [Column(TypeName="VARCHAR(5)")]
        public string ExpiretionDate { get; set; }
        [Column(TypeName="VARCHAR(3)")]
        public string CVV { get; set; }
    }
}