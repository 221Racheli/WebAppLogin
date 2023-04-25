using entities;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppLoginEx1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService service;
        public ProductsController(IProductService service)
        {
            this.service = service;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await service.getProductsWithCategoryAsync();
        }
        [HttpGet("search")]
        public async Task<IEnumerable<Product>> GetbySearch(string desc, int minPrice, int maxPrice)
        {
            return await service.getProductsBySearch(desc, minPrice, maxPrice);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] Product product)
        {
            Product addProduct= await service.addProductAsync(product);
            if(addProduct!=null)
                return CreatedAtAction(nameof(Get), new { id = addProduct.Id }, addProduct);
            return BadRequest();
        }
    }
}
