using System.ComponentModel.DataAnnotations;

namespace ProductSupport.API.DTOs.CompaniesDTO
{
    public class ViewCompanyDTO
    {
        public int? ID { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Country { get; set; }
        public string? Description { get; set; }

        public string? ImagePath { get; set; }
    }
}
