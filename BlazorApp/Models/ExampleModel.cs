using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class ExampleModel : BaseEntity
    {

        [Required]
        [StringLength(10, ErrorMessage="Name is too long")]
        public string Name{get;set;}
    }
}