
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductSupport.API;
using ProductSupport.DTOs.CategoriesDTO;
using ProductSupport.Interfaces;
using ProductSupport.Models;

namespace ProductSupport.Services
{
    public class CategoryService : ControllerBase, ICategoryService
    {
        private readonly AppDbContext _db;

        public CategoryService(AppDbContext db)
        {
            _db = db;
        }



        public async Task<Category> CreateCategory(InputCategoryDTO Createcategory)
        {

            Category newCategory = new Category()
            {
                Name = Createcategory.Name,
                Description = Createcategory.Description,
            };

              _db.Categories.Add(newCategory);
            var result = await _db.SaveChangesAsync();
            if (result <= 0)
                return null;

            return newCategory;
        }

        public Category GetCategoryById(int id)
        {
            var productsInCategory =   _db.Categories.Find(id);

            if (productsInCategory == null)
                return null;

            
            return productsInCategory;



        }

        public async Task<List<Category>> GetAllCategorys()
        {
            return await _db.Categories.ToListAsync();


        }


        public async Task<IActionResult> DeleteById(int id)
        {

            var Findcategory = GetCategoryById(id);

            if (Findcategory == null)
            {
                return NotFound();
            }

             _db.Categories.Remove(Findcategory);
            var result = await _db.SaveChangesAsync();
            if(result <= 0)
                return NotFound();

            return NoContent();

        }

        public async Task<Category> Update(UpdateCategoryDTO input, int id)
        {

            var CategoryFind =  GetCategoryById(id);
            if (CategoryFind == null)
                return null;



            CategoryFind.Name = (input.Name == null) ? CategoryFind.Name : input.Name;
            CategoryFind.Description = (input.Description == null) ? CategoryFind.Description : input.Description;
            _db.Categories.Update(CategoryFind);
          var result = await _db.SaveChangesAsync();
            if (result <= 0)
                return null;


            return GetCategoryById(id);

        }
    }
}
