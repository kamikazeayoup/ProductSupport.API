using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductSupport.DTOs.ProductsDTO;
using ProductSupport.Interfaces;

namespace ProductSupport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(InputProductDTO Createproduct)
        {
            var result = await _productService.CreateProduct(Createproduct);
            if (result == null)
                return NotFound("Cannot create one");
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var result = await _productService.GetProductById(id);
            if (result == null)
                return NotFound();
            return Ok(result);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productService.GetAllProducts();
            if (result == null)
                return NotFound();
            return Ok(result);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(string id)
        {
            return await _productService.DeleteById(id);


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateProductDTO input, string id)
        {
            var result = await _productService.Update(input, id);
            if (result == null)
                return NotFound();

            return Ok(result);


        }

    }

}
