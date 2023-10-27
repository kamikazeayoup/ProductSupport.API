using Microsoft.AspNetCore.Mvc;
using ProductSupport.DTOs.ProductsDTO;
using ProductSupport.Models;

namespace ProductSupport.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateProduct(InputProductDTO Createproduct);
        Task<Product> GetProductById(string id);
        Task<List<Product>> GetAllProducts();
        Task<IActionResult> DeleteById(string id);

        Task<Product> Update(UpdateProductDTO input, string id);

    }
}
