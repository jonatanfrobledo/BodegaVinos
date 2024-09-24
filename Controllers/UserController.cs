using Microsoft.AspNetCore.Mvc;
using BodegaVinos.Services;
using BodegaVinos.Dtos;
using Services;

namespace BodegaVinos.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult RegisterUser(UserDto userDto)
        {
            _userService.RegisterUser(userDto);
            return Ok("Usuario registrado correctamente.");
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }
    }
}
