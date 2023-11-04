using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductSupport.DTOs.CategoriesDTO;
using ProductSupport.Interfaces;

namespace ProductSupport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory(InputCategoryDTO Createcategory)
        {
            var result = await _categoryService.CreateCategory(Createcategory);
            if (result == null)
            {
                return NotFound("Can't Create a new Category");
            }
            return Ok(result);
        }

        [HttpGet("(id)")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result =  _categoryService.GetCategoryById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategorys()
        {
            var result = await _categoryService.GetAllCategorys();
            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpDelete("(id)")]
        public async Task<IActionResult> DeleteById(int id)
        {
            return await _categoryService.DeleteById(id);

        }

        [HttpPut("(id)")]
        public async Task<IActionResult> Update(UpdateCategoryDTO input, int id)
        {
            var result = await _categoryService.Update(input, id);
            if (result == null)
                return NotFound("Cannot Update");

            return Ok(result);

        }
    }

}
