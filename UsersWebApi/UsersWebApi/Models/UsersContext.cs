using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersWebApi.Models
{
    //Context for Users database set
    public class UsersContext: DbContext
    {
        public UsersContext(DbContextOptions <UsersContext> options) : base(options)
        {
        }
        public DbSet <User> Users { get; set; }
    }
}
