using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LibraryApp.Areas.Identity.Data
{
    public class LibraryAppIdentityRole :IdentityRole
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string UserId { get; set; }

        [PersonalData]
        [Column(TypeName = "varchar(50)")]
        public string UserRole { get; set; }
    }
}
