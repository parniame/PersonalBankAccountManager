using Abstraction.Service.Exceptions;
using DataTransferObject;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Service.Exceptions;
using Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceClasses
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        

        public async Task<List<UserResult>> GetAllUser()
        {
            List<User> data = await _userManager.Users.ToListAsync();
            List<UserResult> result = data.Any() ? data.Select(TranslateToDTO<UserResult>).ToList() : new List<UserResult>();
            return result;

        }
        public async Task<User?> GetCurrentUserAsync(string userId)
        {
            var user =  await _userManager.FindByIdAsync(userId);
            return user;
        }
        public async Task<bool> LoginAsync(LoginCommand command)
        {
            var result = false;
            var user = await _userManager.FindByNameAsync(command.UserName);

            if (user != null)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(user, command.Password, command.RememberMe, false);
                result = signInResult.Succeeded;
            }
            else
            {
                throw new UserDoseNotExistException(command.UserName);
            }

            return result;
        }

        public async Task<bool> RegisterAsync(RegisterCommand command, string userRole)
        {
            
            var duplicateUser = await _userManager.FindByNameAsync(command.UserName);
            if (duplicateUser != null)
                throw new DuplicateUserNameException(command.UserName);

            var user = TranslateToEntity<RegisterCommand>(command);
            user.DateCreated = DateTime.Now;

            var registerResult = await _userManager.CreateAsync(user, command.Password);
            await _userManager.AddToRoleAsync(user, userRole);
            


            return registerResult.Succeeded;
        }

        public async Task LogoutAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
                throw new ItemNotFoundException(nameof(User));

            await _signInManager.SignOutAsync();
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

