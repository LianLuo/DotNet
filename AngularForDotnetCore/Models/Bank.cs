using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularForDotnetCore.Models
{
    public class Bank
    {
        [Key]
        public int BankID { get; set; }
        [Column(TypeName="VARCHAR(100)")]
        public string BankName { get; set; }
        [Column(TypeName="VARCHAR(32)")]
        public string ShortName { get; set; }
    }
}