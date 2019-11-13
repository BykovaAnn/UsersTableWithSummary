using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersWebApi.Models
{
    //Model for creating token
    public class AuthenticationOptions
    {
        public string JWT_Secret { get; set; }
        public string Client_URL { get; set; }
    }
}
