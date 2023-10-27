using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.AspNetCore.Mvc;
using ProductSupport.DTOs.ProductsDTO;
using ProductSupport.Interfaces;
using ProductSupport.Models;

namespace ProductSupport.Services
{
    public class ProductService : ControllerBase, IProductService
    {
        private readonly FirebaseClient _firebaseClient;
        private readonly ICategoryService _categoryService;


        public ProductService(ICategoryService categoryService, FirebaseClient firebaseClient)
        {
            _categoryService = categoryService;
            _firebaseClient = firebaseClient;
        }
        public async Task<Product> CreateProduct(InputProductDTO Createproduct)
        {

            Product prodct = new Product()
            {
                ID = Guid.NewGuid().ToString("N"),
                Name = Createproduct.Name,
                Description = Createproduct.Description,
                CategoryID = Createproduct.CategoryID,
                ImageUrl = Createproduct.ImageUrl,

            };

            //check if the Category is Found With given ID
            var CategoryCheck = await _categoryService.GetCategoryById(Createproduct.CategoryID);
            if (CategoryCheck == null)
                return null;

            await _firebaseClient
           .Child("Products")
           .Child(prodct.ID)
           .PutAsync<Product>(prodct);
            return await GetProductById(prodct.ID);


        }


        public async Task<Product> GetProductById(string id)
        {
            var productavailable = await _firebaseClient
                 .Child("Products")
                 .Child(id)
                 .OnceSingleAsync<Product>();

            if (productavailable == null)
                return null;

            Product cat = new Product()
            {
                ID = productavailable.ID,
                Name = productavailable.Name,
                Description = productavailable.Description,
                CategoryID = productavailable.CategoryID,
                ImageUrl = productavailable.ImageUrl
            };
            return cat;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var dinos = await _firebaseClient
            .Child("Products")
            .OnceAsync<Product>();

            List<Product> result = new List<Product>();
            foreach (var cat in dinos)
            {
                result.Add(new Product()
                {
                    ID = cat.Object.ID,
                    Name = cat.Object.Name,
                    Description = cat.Object.Description,
                    CategoryID = cat.Object.CategoryID,
                    ImageUrl = cat.Object.ImageUrl
                });
            }
            return result;
        }


        public async Task<IActionResult> DeleteById(string id)
        {
            var product = await _firebaseClient.Child("Products").Child(id).OnceSingleAsync<Product>();

            if (product == null)
            {
                return NotFound();
            }

            await _firebaseClient.Child("Products").Child(id).DeleteAsync();
            return NoContent();

        }
        public async Task<Product> Update(UpdateProductDTO input, string id)
        {

            var ifAva = await GetProductById(id);
            if (ifAva == null)
                return null;
            Product prod = new Product()
            {
                ID = id,


            };

            //Validation 
            prod.Name = (input.Name == null) ? ifAva.Name : input.Name;
            prod.Description = (input.Description == null) ? ifAva.Description : input.Description;
            prod.CategoryID = (input.CategoryID == null) ? ifAva.CategoryID : input.CategoryID;
            prod.ImageUrl = (input.ImageUrl == null) ? ifAva.ImageUrl : input.ImageUrl;
            if (prod.CategoryID != ifAva.CategoryID)
            {
                var CategoryCheck = await _categoryService.GetCategoryById(prod.ID);
                if (CategoryCheck == null)
                    return null;
            }


            await _firebaseClient
          .Child("Products")
          .Child(prod.ID)
          .PutAsync(prod);

            return await GetProductById(prod.ID);

        }
    }
}
