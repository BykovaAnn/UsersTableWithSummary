using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersWebApi.Models;

namespace UsersWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersAccountController : ControllerBase
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _singInManager;

        public UsersAccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _singInManager = signInManager;
        }

        [HttpPost]
        [Route("Register")]
        //POST : /api/Users/Register
        public async Task<Object> PostApplicationUser(UserRegister model)
        {
            var newUser = new User()
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
                UserActive = true
            };

            try
            {
                var result = await _userManager.CreateAsync(newUser, model.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}