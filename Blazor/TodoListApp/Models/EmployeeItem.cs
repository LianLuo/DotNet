using System.ComponentModel.DataAnnotations;

namespace TodoListApp.Models
{
    public class EmployeeItem
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string EmpCode { get; set; }
        public string Position { get; set; }
        public string Mobile { get; set; }
    }
}