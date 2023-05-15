using Microsoft.AspNetCore.Mvc;
using Prototype.Service;
using System;
using System.Linq;

namespace Prototype.API.Controllers
{
    public class UserController : CommonController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _userService.GetUsers();
            if (users.Count() > 0)
            {
                return Ok(users);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var user = _userService.GetUser(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }
    }
}
