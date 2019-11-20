using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using UsersWebApi.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using UsersWebApi.Helpers;
using Microsoft.Extensions.Logging;

namespace UsersWebApi.Controllers
{
    //Controller for user authorization 

    [Route("api/[controller]")]
    [ApiController]
    public class UsersAccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly AuthenticationOptions _options;

        public UsersAccountController(UserManager<User> userManager, IOptions<AuthenticationOptions> options)
        {
            _userManager = userManager;
            //options consist of JWTSecret and angular localhost url
            _options = options.Value;
        }

        [HttpPost]
        [Route("Register")]
        //POST : /api/UsersAccount/Register
        //Creation of new user
        public async Task<Object> Register(UserRegister model)
        {
            User newUser = AccountHelper.CreateUser(model);
            try
            {
                IdentityResult result = await _userManager.CreateAsync(newUser, model.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Login")]
        //POST : /api/UsersAccount/Login
        //User Authorization
        public async Task<IActionResult> Login(UserLogin model)
        {
            //getting user by username from login form
            User user = await _userManager.FindByNameAsync(model.UserName);
            //if this user data are correct
            bool checkPassword = await _userManager.CheckPasswordAsync(user, model.Password);
            if (user != null && checkPassword)
            {
                //send token to user
                string token = AccountHelper.CreateToken(user, _options.JWTSecret);
                return Ok(new { token });
            }
            else
                return BadRequest(new { message = "Username or password is incorrect." });
        }
    }
}