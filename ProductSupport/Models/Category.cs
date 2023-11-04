using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace ProductSupport.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Product>? Products { get; set; }    
    }
}
