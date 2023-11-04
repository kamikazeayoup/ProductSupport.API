using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductSupport.API.DTOs.CompaniesDTO;
using ProductSupport.API.DTOs.ProductsDTO;
using ProductSupport.API.Interfaces;
using ProductSupport.API.Models;
using ProductSupport.Models;

namespace ProductSupport.API.Services
{
    public class CompanyService : ControllerBase, ICompanyService
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        private readonly IImageService _imageservice;
        public CompanyService(AppDbContext db , IMapper mapper , IImageService imageService)
        {
            _db = db;
            _mapper = mapper;
            _imageservice = imageService;
        }
        public async Task<ViewCompanyDTO> CreateCompany(InputCompanyDTO Createcompany)
        {
            Company newCompany = new Company()
            {
                Name = Createcompany.Name,
                Code = Createcompany.Code,
                Description = Createcompany.Description,
                Country = Createcompany.Country,

            };


            //check if The Code Unique Or Not 
            var CheckCode = _db.Companies.FirstOrDefault(i => i.Code == Createcompany.Country);
            if (CheckCode != null)
                return null;

            //Add The Photo
            if (Createcompany.Base64Image != null)
            {
                newCompany.Imagepath = _imageservice.SaveImage(Createcompany.Base64Image, newCompany.Code, "Companies");

            }

            await _db.Companies.AddAsync(newCompany);
            var result = await _db.SaveChangesAsync();
            if (result <= 0)
            {
                _imageservice.DeleteImage(newCompany.Imagepath);
                return null;
            }
            ViewCompanyDTO ViewCompany = new ViewCompanyDTO();
            ViewCompany = _mapper.Map<ViewCompanyDTO>(newCompany);

            return ViewCompany;
        }

        public async Task<IActionResult> DeleteById(int id)
        {
            var company = await _db.Companies.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            if (company.Imagepath != null)
                _imageservice.DeleteImage(company.Imagepath);

            _db.Companies.Remove(company);
            var result = await _db.SaveChangesAsync();
            if (result <= 0)
                return NotFound();


            return NoContent();
        }

        public async Task<List<ViewCompanyDTO>> GetAllCompanies()
        {
            List<ViewCompanyDTO> Allcompanies = new List<ViewCompanyDTO>();
            var listedcompanies = _db.Companies.ToList();
            foreach (var company in listedcompanies)
            {
                ViewCompanyDTO comp = new ViewCompanyDTO();
                comp = _mapper.Map<ViewCompanyDTO>(company);

                Allcompanies.Add(comp);
            }
            return Allcompanies;
        }

        public ViewCompanyDTO GetCompanyById(int id)
        {
            var Companyavailable = _db.Companies.Find(id);

            if (Companyavailable == null)
                return null;
            ViewCompanyDTO viewCompany = new ViewCompanyDTO();
            viewCompany = _mapper.Map<ViewCompanyDTO>(Companyavailable);


            return viewCompany;
        }

        public async Task<ViewCompanyDTO> Update(UpdateCompanyDTO input, int id)
        {
            var CompanyFind = await _db.Companies.FindAsync(id);
            if (CompanyFind == null)
                return null;

            //Validation 
            CompanyFind.Name = (input.Name == null) ? CompanyFind.Name : input.Name;
            CompanyFind.Description = (input.Description == null) ? CompanyFind.Description : input.Description;
            CompanyFind.Code = (input.Code == null) ? CompanyFind.Code : input.Code;
            CompanyFind.Country = (input.Country == null) ? CompanyFind.Country : input.Country;

            //Check if The Photo Changed
            if (input.Base64Image != null)
            {
                if (CompanyFind.Imagepath != null)
                    _imageservice.DeleteImage(CompanyFind.Imagepath);

                CompanyFind.Imagepath = _imageservice.SaveImage(input.Base64Image, CompanyFind.Code, "Companies");
            }

            _db.Companies.Update(CompanyFind);
            var result = await _db.SaveChangesAsync();
            if (result <= 0)
                return null;
            //Display After Update
            ViewCompanyDTO viewCompany = new ViewCompanyDTO();
            viewCompany = _mapper.Map<ViewCompanyDTO>(CompanyFind);
            return viewCompany;
        }
    }
}
