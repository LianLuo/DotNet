using System.ComponentModel.DataAnnotations.Schema;

namespace ResturantWebApp.Models
{
    public class CustomerEntity : BaseEntity
    {
        [Column(TypeName = "NVARCHAR(64)")]
        public string CustomerName { get; set; }
        [Column(TypeName = "VARCHAR(26)")]
        public string Mobile { get; set; }
        [Column(TypeName = "NVARCHAR(128)")]
        public string Address { get; set; }
        [Column(TypeName = "VARCHAR(24)")]
        public string IDCard { get; set; }
        public int Gender { get; set; } = 0;
        public int CountryID { get; set; }
        public int CityID { get; set; }
        public int StreemID { get; set; }
        [Column(TypeName = "NVARCHAR(128)")]
        public string DoorNumber { get; set; }
    }
}