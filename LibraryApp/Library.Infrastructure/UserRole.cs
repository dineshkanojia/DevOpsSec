using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Library.Infrastructure
{
    public partial class UserRole
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}
