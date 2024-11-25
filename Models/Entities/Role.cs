using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public Role() { }   

        public Role(string roleName) : base(roleName)
        {
        }

        public string? PersianName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
       
    }
}
