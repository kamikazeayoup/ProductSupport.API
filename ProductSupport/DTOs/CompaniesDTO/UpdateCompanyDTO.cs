using System.ComponentModel.DataAnnotations;

namespace ProductSupport.API.DTOs.CompaniesDTO
{
    public class UpdateCompanyDTO
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Country { get; set; }
        public string? Description { get; set; }
        public string? Base64Image { get; set;}
    }
}
