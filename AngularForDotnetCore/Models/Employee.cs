using System.ComponentModel.DataAnnotations;

namespace AngularForDotnetCore.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public string EMPCode { get; set; }
        public string Mobile { get; set; }
        public string Position { get; set; }
    }
}