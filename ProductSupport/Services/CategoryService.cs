using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.AspNetCore.Mvc;
using ProductSupport.DTOs.CategoriesDTO;
using ProductSupport.Interfaces;
using ProductSupport.Models;

namespace ProductSupport.Services
{
    public class CategoryService : ControllerBase, ICategoryService
    {
        private readonly FirebaseClient _firebaseClient;

        public CategoryService(FirebaseClient firebaseClient)
        {
            _firebaseClient = firebaseClient;
        }



        public async Task<Category> CreateCategory(InputCategoryDTO Createcategory)
        {

            Category newCategory = new Category()
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = Createcategory.Name,
                Description = Createcategory.Description,
            };
            await _firebaseClient
           .Child("Categorys")
           .Child(newCategory.Id)
           .PutAsync(newCategory);

            return await GetCategoryById(newCategory.Id);
        }

        public async Task<Category> GetCategoryById(string id)
        {
            var productsInCategory = await _firebaseClient
                .Child("Categorys")
                .Child(id)
                .OnceSingleAsync<Category>();

            if (productsInCategory == null)
                return null;

            Category cat = new Category()
            {
                Id = productsInCategory.Id,
                Name = productsInCategory.Name,
                Description = productsInCategory.Description
            };
            return cat;



        }

        public async Task<List<Category>> GetAllCategorys()
        {
            var dinos = await _firebaseClient
            .Child("Categorys")
            .OnceAsync<Category>();

            List<Category> result = new List<Category>();
            foreach (var cat in dinos)
            {
                result.Add(new Category()
                {
                    Id = cat.Object.Id,
                    Name = cat.Object.Name,
                    Description = cat.Object.Description
                });
            }
            return result;


        }


        public async Task<IActionResult> DeleteById(string id)
        {

            var category = await _firebaseClient.Child("Categorys").Child(id).OnceSingleAsync<Category>();

            if (category == null)
            {
                return NotFound();
            }
            var productsInCategory = await _firebaseClient.Child("Products")
                .OrderBy("CategoryID")
                .EqualTo(id)
                .OnceAsync<Product>();
            if (productsInCategory.Count > 0)
            {
                return NotFound("Can't delete, There's products Depends on this");
            }

            await _firebaseClient.Child("Categorys").Child(id).DeleteAsync();
            return NoContent();

        }

        public async Task<Category> Update(UpdateCategoryDTO input, string id)
        {

            var ifAva = await GetCategoryById(id);
            if (ifAva == null)
                return null;
            Category cat = new Category()
            {
                Id = id,


            };

            //Validation 
            cat.Name = (input.Name == null) ? ifAva.Name : input.Name;
            cat.Description = (input.Description == null) ? ifAva.Description : input.Description;

            await _firebaseClient
          .Child("Categorys")
          .Child(cat.Id)
          .PutAsync(cat);

            return await GetCategoryById(cat.Id);


        }
    }
}
