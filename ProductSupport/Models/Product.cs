using ProductSupport.API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductSupport.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int CategoryID { get; set; }
        public int CompanyID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        [ForeignKey("CompanyID")]
        public virtual Company Company { get; set; }

        public string? ImagePath { get; set; }

    }
}
