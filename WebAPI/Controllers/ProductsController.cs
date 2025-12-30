using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

 
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return Ok(product);
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Products.ToList());
        }


        [HttpGet("{productId}")]
        public IActionResult GetById(int productId)
        {
            var product = _context.Products.Find(productId);

            if (product == null)
                return NotFound();

            return Ok(product);
        }





    }
}