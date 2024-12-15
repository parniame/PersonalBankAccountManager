using DataTransferObject;
using Microsoft.AspNetCore.Identity;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceInterfaces
{
    public interface IUserService
    {
        //Task<IdentityResult> CreateUser(RegisterCommand user, string password,Guid userId);
        Task<User> GetCurrentUserAsync( string userId);
        Task<List<UserResult>> GetAllUser();
        Task<bool> LoginAsync(LoginCommand command);
        Task<bool> RegisterAsync(RegisterCommand command,string userRole);
        Task LogoutAsync(string username);
    }
}
