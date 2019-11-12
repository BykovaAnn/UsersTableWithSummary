using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UsersWebApi.Models
{
    public class User : IdentityUser
    {
        //PK
        //[Key]
        //public int UserID { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string FullName { get; set; }

        [DefaultValue(false)]
        [Required]
        public bool UserActive { get; set; }
    }
}
