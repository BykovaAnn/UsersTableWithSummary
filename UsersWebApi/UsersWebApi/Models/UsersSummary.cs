using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersWebApi.Models
{
    //class for pop-up window with total User count and active User count
    public class UsersSummary
    {
        public int UsersCount { get; set; }
        public int UsersActive { get; set; }
    }
}
