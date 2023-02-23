using Microsoft.AspNetCore.Mvc;
using System.Reflection.PortableExecutable;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppLoginEx1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {

        string filePath = "./usersDetails.txt";

        // GET: api/<usersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<usersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // POST api/<usersController>


        [HttpPost]
        public ActionResult<User> LoginPost([FromBody] User loginUser)
        {
            User found = foundUser(loginUser);
            if (found != null)
                return found;
            return NoContent();
        }



        [HttpPost("regist")]
        public ActionResult<User> Post([FromBody] User userRegist)
        {
            if (!existUserName(userRegist.email))
            {
                Console.WriteLine("regist controler");
                int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
                userRegist.userId = numberOfUsers + 1;
                string userJson = JsonSerializer.Serialize(userRegist);
                System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
                return CreatedAtAction(nameof(Get), new { id = userRegist.userId }, userRegist);
            }
            return BadRequest("email already exists");

        }


        // PUT api/<usersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.userId == id)
                        textToReplace = currentUserInFile;
                }
            }
            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(filePath, text);
            }

        }

        // DELETE api/<usersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public User foundUser(User userToSearch)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.email == userToSearch.email && user.password == userToSearch.password)
                        return user;
                }
            }
            return null;
        }

        public Boolean existUserName(String userName)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.email == userName)
                        return true;
                }
            }
            return false;
        }
    }
}
