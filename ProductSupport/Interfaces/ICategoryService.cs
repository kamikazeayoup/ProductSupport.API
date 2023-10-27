using Microsoft.AspNetCore.Mvc;
using ProductSupport.DTOs.CategoriesDTO;
using ProductSupport.Models;

namespace ProductSupport.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> CreateCategory(InputCategoryDTO Createcategory);
        Task<List<Category>> GetAllCategorys();
        Task<Category> GetCategoryById(string id);
        Task<IActionResult> DeleteById(string id);
        Task<Category> Update(UpdateCategoryDTO input, string id);
    }
}
