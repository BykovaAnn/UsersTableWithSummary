using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersWebApi.Models;

namespace UsersWebApi.Controllers
{
    //Api Controller for UsersSummary model

    [Route("api/[controller]")]
    [ApiController]
    public class UsersSummaryController : ControllerBase
    {
        private readonly UsersContext _context;
        public UsersSummaryController(UsersContext context)
        {
            _context = context;
        }

        // GET: api/UsersSummary
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UsersSummary>> GetUsersSummary()
        {
            UsersSummary usersSummary = new UsersSummary();
            usersSummary.UsersCount = await _context.ApplicationUsers.CountAsync<User>();
            usersSummary.UsersActive = await _context.ApplicationUsers.CountAsync<User>(res => res.UserActive);
            return usersSummary;
        }


    }
}