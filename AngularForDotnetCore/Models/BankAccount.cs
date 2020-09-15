using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularForDotnetCore.Models
{
    public class BankAccount
    {
        [Key]
        public int BankAccountID { get; set; }
        [Column(TypeName="VARCHAR(18)")]
        [Required]
        public string AccountNumber { get; set; }
        [Column(TypeName="VARCHAR(64)")]
        [Required]
        public string AccountHolder { get; set; }
        [Required]
        public int BankID { get; set; }
        [Column(TypeName="VARCHAR(256)")]
        [Required]
        public string Remark { get; set; }
    }
}