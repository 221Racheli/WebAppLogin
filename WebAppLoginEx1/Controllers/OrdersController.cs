using entities;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppLoginEx1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderService service;
        public OrdersController(IOrderService service)
        {
            this.service = service;
        }


        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<Order> Get(int id)
        {
            return await service.getOrderAsync(id);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] Order order)
        {
            Order orderCreated=await service.addOrderAsync(order);
            if (orderCreated != null)
                return CreatedAtAction(nameof(Get), new { id = orderCreated.Id }, orderCreated);
            return BadRequest();
    }


    }
}
