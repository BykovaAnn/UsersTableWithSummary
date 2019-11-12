using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        private UsersSummary usersSummary;
        public UsersSummaryController(UsersContext context)
        {
            _context = context;
            usersSummary = new UsersSummary();
        }

        // GET: api/UsersSummary
        [HttpGet]
        public async Task<ActionResult<UsersSummary>> GetUsersSummary()
        {
            usersSummary.UsersCount = await _context.ApplicationUsers.CountAsync<User>();
            usersSummary.UsersActive = await _context.ApplicationUsers.CountAsync<User>(res => res.UserActive);
            return usersSummary;
        }
    }
}