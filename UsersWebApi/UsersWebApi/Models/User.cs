using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UsersWebApi.Models
{
    public class User
    {
        //PK
        [Key]
        public int UserID { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        [Required]
        //[MaxLength(500)]
        public string UserName { get; set; }

        [DefaultValue(false)]
        [Required]
        public bool UserActive { get; set; }
    }
}
