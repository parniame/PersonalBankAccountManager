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
        Task<User> GetUserAsync( string userId);
        Task<bool> LoginAsync(LoginCommand command);
        Task LogoutAsync(string username);
        Task DeleteUserAsync(Guid userId);
        Task<List<UserResult>> GetAllUserAsync(Guid userId);
        Task<UserResult> GetCurrentUserAsync(Guid userId);
        Task<bool> RegisterAsync(RegisterCommand command, string userRole, Guid userId = default);
        Task<bool> UpdatePasswordAsync(string userName, string password); 
        Task<bool> UpdateUserAsync(RegisterCommand dto, Guid userId, string oldUsername);
    }
}
