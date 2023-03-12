using entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Reflection.PortableExecutable;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppLoginEx1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {

        UserService service = new UserService();
        PasswordsService servicePass = new PasswordsService();

        string filePath = "./usersDetails.txt";

        // GET: api/<usersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<usersController>/5
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await service.getbyIdAsync(id);
        }


        // POST api/<usersController>


        [HttpPost]
        public async Task<ActionResult<User>> LoginPost([FromBody] User loginUser)
        {
            User found = await service.loginAsync(loginUser);
            if (found != null)
                return found;
            return NoContent();
        }



        [HttpPost("regist")]
        public async Task<ActionResult<User>> Post([FromBody] User userRegist)
        {
            Password pass = new Password(userRegist.password);
            if (servicePass.getPasswordRate(pass) > 2)
            {
                User userCreated = await service.registerAsync(userRegist);
                if (userCreated != null)
                    return CreatedAtAction(nameof(Get), new { id = userCreated.userId }, userCreated);
            }
            return BadRequest("email already exists");
        }



        // PUT api/<usersController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User userToUpdate)
        {
            await service.updateAsync(userToUpdate, id);

        }

        // DELETE api/<usersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
