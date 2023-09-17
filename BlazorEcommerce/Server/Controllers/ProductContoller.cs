
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductContoller : ControllerBase
    {
        private readonly DataContext _context;

        public ProductContoller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProduct()
        {
            var products = _context.Products.ToList();
             return Ok(products);
        }

    }
}
