using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UsersWebApi.Models
{
    //Context for Users database set
    public class UsersContext: IdentityDbContext
    {
        public UsersContext(DbContextOptions <UsersContext> options) : base(options)
        {
        }
        public DbSet <User> ApplicationUsers { get; set; }
    }
}
