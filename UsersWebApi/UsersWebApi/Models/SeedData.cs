﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersWebApi.Models
{
    //For filling Users table with data
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UsersContext(serviceProvider.GetRequiredService<DbContextOptions<UsersContext>>()))
            {
                // Look for any Users
                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }

                context.Users.AddRange(
                    new User
                    {
                        UserName = "AdamFinch0980",
                        UserActive = false
                    },

                    new User
                    {
                        UserName = "Cortney19",
                        UserActive = true
                    },

                    new User
                    {
                        UserName = "Will_i_am",
                        UserActive = false
                    },

                    new User
                    {
                        UserName = "SamDavidson",
                        UserActive = true
                    },

                    new User
                    {
                        UserName = "Clay_0706",
                        UserActive = true
                    },

                    new User
                    {
                        UserName = "Agent_Code",
                        UserActive = false
                    },

                    new User
                    {
                        UserName = "Serena10",
                        UserActive = false
                    },

                    new User
                    {
                        UserName = "RenleyBaratheon",
                        UserActive = true
                    },

                    new User
                    {
                        UserName = "StannisBaratheon",
                        UserActive = true
                    },

                    new User
                    {
                        UserName = "Dan",
                        UserActive = false
                    }
                ) ;
                context.SaveChanges();
            }
        }
    }
}
