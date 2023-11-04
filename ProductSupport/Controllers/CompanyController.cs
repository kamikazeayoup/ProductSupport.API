using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductSupport.API.DTOs.CompaniesDTO;
using ProductSupport.API.Interfaces;
using ProductSupport.DTOs.ProductsDTO;

namespace ProductSupport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;   
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(InputCompanyDTO Createcompany)
        {
            var result = await _companyService.CreateCompany(Createcompany);
            if (result == null)
                return NotFound("Cannot create one");
            return Ok(result);

        }

        [HttpGet("(id)")]
        public async Task<IActionResult> GetComapnyById(int id)
        {
            var result = _companyService.GetCompanyById(id);
            if (result == null)
                return NotFound();
            return Ok(result);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            var result = await _companyService.GetAllCompanies();
            if (result == null)
                return NotFound();
            return Ok(result);

        }


        [HttpDelete("(id)")]
        public async Task<IActionResult> DeleteById(int id)
        {

            return await _companyService.DeleteById(id);


        }

        [HttpPut("(id)")]
        public async Task<IActionResult> Update(UpdateCompanyDTO input, int id)
        {
            var result = await _companyService.Update(input, id);
            if (result == null)
                return NotFound();

            return Ok(result);


        }
    }
}
