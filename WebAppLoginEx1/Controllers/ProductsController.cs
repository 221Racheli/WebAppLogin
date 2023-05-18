using AutoMapper;
using DTO;
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
        IMapper mapper;
        public ProductsController(IProductService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            IEnumerable<Product> products = await service.getProductsWithCategoryAsync();
            if (products!=null)
            {
                IEnumerable<ProductDTO> productsDTO = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
                return Ok(productsDTO);
            }
            return BadRequest("no products");

        }
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetbySearch([FromQuery] IEnumerable<string>? categoryId, string? desc, int? minPrice, int? maxPrice)
        {
            IEnumerable<Product> products = await service.getProductsBySearch(desc, minPrice, maxPrice, categoryId);
            if (products!=null)
            {
                IEnumerable<ProductDTO> productsDTO = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
                return Ok(productsDTO);
            }
            return BadRequest("no products");

        }


        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Post([FromBody] ProductDTO productDTO)
        {
            Product product = mapper.Map<ProductDTO, Product>(productDTO);
            Product addProduct = await service.addProductAsync(product);
            if (addProduct != null)
            {
                ProductDTO addProductDTO = mapper.Map<Product, ProductDTO>(addProduct);
                return CreatedAtAction(nameof(Get), new { id = addProductDTO.Id }, addProductDTO);
            }
            return BadRequest();
        }
    }
}
