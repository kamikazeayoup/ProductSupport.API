using Microsoft.AspNetCore.Mvc;
using ProductSupport.API.DTOs.ProductsDTO;
using ProductSupport.DTOs.ProductsDTO;
using ProductSupport.Models;

namespace ProductSupport.Interfaces
{
    public interface IProductService
    {
        Task<ViewProductDTO> CreateProduct(InputProductDTO Createproduct);
        ViewProductDTO GetProductById(int id);
        Task<List<ViewProductDTO>> GetAllProducts();
        Task<IActionResult> DeleteById(int id);

        Task<ViewProductDTO> Update(UpdateProductDTO input, int id);

    }
}
