using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_intro.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_intro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("{tz}")]
        public async Task<IActionResult> GetIsValid(string tz)
        {
            var res = await _usersService.IsUserValid(tz);
            return Ok(res);
        }
    }
}
