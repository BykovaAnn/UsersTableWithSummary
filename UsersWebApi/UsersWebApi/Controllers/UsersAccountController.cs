using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using UsersWebApi.Models;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;

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
            //options consist of JWT_Secret and angular localhost url
            _options = options.Value;
        }

        [HttpPost]
        [Route("Register")]
        //POST : /api/UsersAccount/Register
        //Creation of new user
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

        [HttpPost]
        [Route("Login")]
        //POST : /api/UsersAccount/Login
        //User Authorization
        public async Task<IActionResult> Login(UserLogin model)
        {
            //getting user by username from login form
            var user = await _userManager.FindByNameAsync(model.UserName);
            //if this user data are correct
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                //create token for user
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString())
                    }),
                    //after 10 min token expires
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    //encryption parameters
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.JWT_Secret)), 
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                //create token w/ described parameters
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                //send token to user
                return Ok(new { token });
            }
            else
                return BadRequest(new { message = "Username or password is incorrect." });
        }
    }
}