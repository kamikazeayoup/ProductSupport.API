using Microsoft.AspNetCore.Mvc;
using ProductSupport.API.DTOs.CompaniesDTO;
using ProductSupport.API.DTOs.ProductsDTO;
using ProductSupport.DTOs.ProductsDTO;

namespace ProductSupport.API.Interfaces
{
    public interface ICompanyService
    {
        Task<ViewCompanyDTO> CreateCompany(InputCompanyDTO Createcompany);
        ViewCompanyDTO GetCompanyById(int id);
        Task<List<ViewCompanyDTO>> GetAllCompanies();
        Task<IActionResult> DeleteById(int id);

        Task<ViewCompanyDTO> Update(UpdateCompanyDTO input, int id);
    }
}
