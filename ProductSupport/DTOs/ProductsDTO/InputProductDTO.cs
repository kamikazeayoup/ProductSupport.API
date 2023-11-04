namespace ProductSupport.DTOs.ProductsDTO
{
    public class InputProductDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public int CategoryID { get; set; }
        public int CompanyID { get; set; }

        public string? Base64Image { get; set; }
    }
}
