using WebsiteDesign.Models;

namespace WebsiteDesign.Services
{
    public class ProductService
    {
        public List<ProductModel> GetProducts()
        {
            return new List<ProductModel>
            {
                new ProductModel
                {
                    Id=1,
                    Name = "Leather Bag",
                    Category = "Lifestyle",
                    Image = "/images/bag.jpg",
                    Price= 5000,
                    Description = "Premium full-grain leather bag, crafted for durability and a luxurious finish.\r\n\r\nDimensions: 15” L x 11” H x 5” W, ideal for laptops, documents, and daily essentials.\r\n\r\nFeatures multiple compartments, including a padded laptop sleeve and secure zip pockets.\r\n\r\nAdjustable shoulder strap and sturdy top handles for versatile carrying options.\r\n\r\nSleek design with reinforced stitching and high-quality metal hardware for long-lasting use."
                },
                new ProductModel
                {
                    Id=2,
                    Name = "Mobile Phone",
                    Category = "Electronics",
                    Image = "/images/mobile.png",
                     Price= 5000,
                    Description = "Sleek smartphone with a 6.7-inch AMOLED display, offering vibrant colors and smooth visuals.\r\n\r\nPowered by an octa-core processor with 8GB RAM and 128GB internal storage for seamless multitasking.\r\n\r\nTriple rear camera setup (108MP + 12MP + 5MP) and 32MP front camera for high-quality photos and videos.\r\n\r\nLong-lasting 5000mAh battery with fast charging support for all-day usage.\r\n\r\nRuns on the latest Android OS with fingerprint sensor, face unlock, and 5G connectivity.."
                },
                new ProductModel
                {
                    Id=3,
                    Name = "Laptop Corei5 8thGen",
                    Category = "Electronics",
                    Image = "/images/laptop.jpg",
                     Price= 5000,
                    Description = "Intel Core i5 8th generation laptop, perfect for business and development."
                },
                new ProductModel
                {
                    Id=4,
                    Name = "FIFA Football",
                    Category = "Sports",
                    Image = "/images/football.jpg",
                     Price= 5000,
                    Description = "Official size FIFA approved football for training and matches."
                },
                new ProductModel
                {
                    Id=5,
                    Name = "Cricket Bat",
                    Category = "Sports",
                    Image = "/images/cricketbat.jpg",
                     Price= 5000,
                    Description = "High quality English willow cricket bat for professional play."
                },
                new ProductModel
                {
                    Id=6,
                    Name = "Electric Scooty 800W",
                    Category = "Automobile",
                    Image = "/images/scooty.jpg",
                     Price= 5000,
                    Description = "800W electric scooty with strong motor and long-range battery."
                }
            };
        }
    }
}
