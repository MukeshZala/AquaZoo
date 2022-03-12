using AquaZooAPI.Models;
using AquaZooAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AquaZooAPI.Controllers
{
    

    [Route("api/v{version:apiVersion}/Users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;

        public UsersController( IUserRepository userRepository)
        {
            _repo = userRepository; 
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticationModel model)
        {
            var user = _repo.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect."});

            return Ok(user); 


        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] AuthenticationModel model)
        {
            bool isUniqueUser = _repo.IsUniqueUser(model.Username);

            if (!isUniqueUser)
            {
                return BadRequest(new { message = "User name already exists !!" }); 
            }

            var user = _repo.Register(model.Username, model.Password); 


 
            return Ok(user);


        }
    }
}
