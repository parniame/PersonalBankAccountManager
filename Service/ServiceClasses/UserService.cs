using DataTransferObject;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceClasses
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;


        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUser(RegisterUserDTO user, string password)
        {
            var data = TranslateToEntity<RegisterUserDTO>(user);
            var result = await _userManager.CreateAsync(data, password);

            return result;
        }

        public async Task<List<UserDTO>> GetAllUser()
        {
            List<User> data = await _userManager.Users.ToListAsync();
            List<UserDTO> result = data.Any() ? data.Select(TranslateToDTO<UserDTO>).ToList() : new List<UserDTO>();
            return result;

        }
        public async Task<UserDTO> GetCurrentUserAsync(string userName, string userId)
        {
            var user = await _userManager.FindByNameAsync(userName) ??
                             await _userManager.FindByIdAsync(userId);
            return TranslateToDTO<UserDTO>(user);
        }

        public DTO TranslateToDTO<DTO>(User entity)
        {
            return entity.Adapt<DTO>();
        }

        public User TranslateToEntity<DTO>(DTO dto)
        {
            return dto.Adapt<User>();
        }
    }

}

