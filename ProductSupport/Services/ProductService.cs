using AutoMapper;
using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductSupport.API;
using ProductSupport.API.DTOs.ProductsDTO;
using ProductSupport.API.Interfaces;
using ProductSupport.DTOs.ProductsDTO;
using ProductSupport.Interfaces;
using ProductSupport.Models;

namespace ProductSupport.Services
{
    public class ProductService : ControllerBase, IProductService
    {
        private readonly AppDbContext _db;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IImageService _imageservice;


        public ProductService(IImageService imageService, AppDbContext db , IMapper mapper , ICategoryService categoryService)
        {
            _imageservice = imageService;
            _db = db;
            _mapper = mapper;
            _categoryService = categoryService;
        }
        public async Task<ViewProductDTO> CreateProduct(InputProductDTO Createproduct)
        {

            Product newProduct = new Product()
            {
                Name = Createproduct.Name,
                Code = Createproduct.Code,
                Description = Createproduct.Description,
                CategoryID = Createproduct.CategoryID,
                CompanyID = Createproduct.CompanyID,

            };

            //Check if The Category Exists
            var CategoryCheck =  _categoryService.GetCategoryById(newProduct.CategoryID);
            if (CategoryCheck == null || newProduct.Code == "")
                return null;

            //Check if The Company Exists
            var CompanyCheck = _db.Companies.Find(newProduct.CompanyID);
            if (CompanyCheck == null)
                return null;

            //check if The Code Unique Or Not 
            var CheckCode = _db.Products.FirstOrDefault(i => i.Code == newProduct.Code);
            if (CheckCode != null)
                return null;

            //Add The Photo
            if(Createproduct.Base64Image != null)
            {
            newProduct.ImagePath = _imageservice.SaveImage(Createproduct.Base64Image  , newProduct.Code, "Products");
                
            }

            await _db.Products.AddAsync(newProduct);
            var result = await _db.SaveChangesAsync();
            if (result <= 0)
            {
                _imageservice.DeleteImage(newProduct.ImagePath);
                return null;
            }
            ViewProductDTO viewProduct = new ViewProductDTO();
            viewProduct = _mapper.Map<ViewProductDTO>(newProduct);
            
            return viewProduct;
        }


        
        public ViewProductDTO GetProductById(int id)
        {
            var productavailable = _db.Products.Find(id);

            if (productavailable == null)
                return null;
            ViewProductDTO viewProduct = new ViewProductDTO();
            viewProduct = _mapper.Map<ViewProductDTO>(productavailable);

            
            return viewProduct;
        }

        public async Task<List<ViewProductDTO>> GetAllProducts()
        {
            List< ViewProductDTO > AllProducts = new List<ViewProductDTO> ();
            var listedproducts = _db.Products.ToList();
            foreach(var product in listedproducts) 
            {
                ViewProductDTO prod = new ViewProductDTO();
                prod = _mapper.Map<ViewProductDTO>(product);
               
                AllProducts.Add(prod);
            }
            return AllProducts;
        }


        public async Task<IActionResult> DeleteById(int id)
        {
            var product = await _db.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            
            if(product.ImagePath != null)
                _imageservice.DeleteImage(product.ImagePath);

            _db.Products.Remove(product);
            var result = await _db.SaveChangesAsync();
            if (result <= 0)
                return NotFound();


            return NoContent();

        }
        public async Task<ViewProductDTO> Update(UpdateProductDTO input, int id)
        {

            var ProductFind = await _db.Products.FindAsync(id);
            if (ProductFind == null)
                return null;
            
            //Validation 
            ProductFind.Name = (input.Name == null) ? ProductFind.Name : input.Name;
            ProductFind.Description = (input.Description == null) ? ProductFind.Description : input.Description;
            ProductFind.Code = (input.Code == null) ? ProductFind.Code : input.Code;
            ProductFind.CategoryID = (input.CategoryID == null) ? ProductFind.CategoryID : (int)input.CategoryID;
           //Check if the Category Changed
            if (ProductFind.CategoryID == input.CategoryID)
            {
                var CategoryCheck = _categoryService.GetCategoryById(ProductFind.CategoryID);
                if (CategoryCheck == null)
                    return null;
            }
            //check if the company changed
            if(ProductFind.CompanyID  == input.CompanyID)
            {
                var CompanyCheck = _db.Companies.Find(input.CompanyID);
                if (CompanyCheck == null)
                    return null;

            }
            //Check if The Photo Changed
            if (input.Base64Image != null)
            {
                if (ProductFind.ImagePath != null)
                    _imageservice.DeleteImage(ProductFind.ImagePath);

                ProductFind.ImagePath = _imageservice.SaveImage(input.Base64Image, ProductFind.Code  , "Products");
            }

            _db.Products.Update(ProductFind);
            var result = await _db.SaveChangesAsync();
            if (result <= 0)
                return null;
            //Display After Update
            ViewProductDTO viewProduct = new ViewProductDTO();
            viewProduct = _mapper.Map<ViewProductDTO>(ProductFind);
            return viewProduct;

        }
    }
}
