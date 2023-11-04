using ProductSupport.Models;
using System.ComponentModel.DataAnnotations;

namespace ProductSupport.API.Models
{
    public class Company
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        [Required]
        public string Code { get; set; }
        public string? Country { get; set; }
        public string? Description { get; set; }

        public string? Imagepath { get; set; }
        public List<Product>? Products { get; set; }

    }
}
