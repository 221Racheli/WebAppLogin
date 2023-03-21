using entities;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppLoginEx1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        ICategoryService service;
        public CategoriesController(ICategoryService service)
        {
            this.service = service;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            IEnumerable<Category> categories = await service.getAllCategoriesAsync();
            if (categories != null)
                return Ok(categories);
            return BadRequest("No categories 😢");
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult<Category>> Post([FromBody] Category category)
        {
            Category categoryCreated = await service.addCategoryAsync(category);
            if (categoryCreated != null)
                return CreatedAtAction(nameof(Get), new { id = categoryCreated.Id }, categoryCreated);
            return BadRequest();
        }
    }
}
