namespace ProductSupport.API.DTOs.ProductsDTO
{
    public class ViewProductDTO
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public int? CategoryID { get; set; }
        public int? CompanyID { get; set; }

        public string? ImagePath { get; set; }
    }
}
