using Microsoft.AspNetCore.Mvc;
using ProductSupport.DTOs.CategoriesDTO;
using ProductSupport.Models;

namespace ProductSupport.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> CreateCategory(InputCategoryDTO Createcategory);
        Task<List<Category>> GetAllCategorys();
        Category GetCategoryById(int id);
        Task<IActionResult> DeleteById(int id);
        Task<Category> Update(UpdateCategoryDTO input, int id);
    }
}
