using DataTransferObject;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceInterfaces
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUser(RegisterUserDTO user, string password);
        Task<UserDTO> GetCurrentUserAsync(string userName, string userId);
        Task<List<UserDTO>> GetAllUser();
    }
}
