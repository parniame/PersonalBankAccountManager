using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatorName { get; set; }
        
        public DateTime? DateUpdated { get; set; }
        public string? UpdatorName { get; set; }
        
    }
}
