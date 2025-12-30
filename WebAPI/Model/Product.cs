using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model
{
    public class Product
    {

        [Key]
        public int ProductId { get; set; }

        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public category ProductCategory { get; set; }

        public string ImageUrl { get; set; } 
    }
}
