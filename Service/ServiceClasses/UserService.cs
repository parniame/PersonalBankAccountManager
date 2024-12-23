using Abstraction.Domain;
using Abstraction.Service.Exceptions;
using DataTransferObject;
using DocumentFormat.OpenXml.Spreadsheet;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Persistence.Repositories;
using Service.Exceptions;
using Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceClasses
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IBaseRepository<TransactionPlan> _planRepo;
        private readonly IBaseRepository<Transaction> _transcationRepo;
        private readonly IBaseRepository<BankAccount> _bankAccountRepo;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IBaseRepository<TransactionPlan> baseRepository, IBaseRepository<Transaction> transcationRepo, IBaseRepository<BankAccount> bankAccountRepo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _planRepo = baseRepository;
            _transcationRepo = transcationRepo;
            _bankAccountRepo = bankAccountRepo;
        }


        public async Task<List<UserResult>> GetAllUserAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                throw new ItemNotFoundException("کاربر ");
            List<User> users = await _userManager.Users.Where(x => x.Id != userId).Include(x => x.Creator).Include(x => x.Updator).ToListAsync();
            List<UserResult> result = new List<UserResult>();
            if (users.Any())
            {
                foreach (User data in users)
                {
                    var dto = await TranslateToResultAsync(data);
                    result.Add(dto);
                }

            }
            return result;

        }
        //used in controller
        public async Task<UserResult> GetCurrentUserAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                throw new ItemNotFoundException("کاربر ");

            var dto = await TranslateToResultAsync(user);
            return dto;

        }
        //used  in services
        public async Task<User?> GetUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            return user;
        }
        public async Task<bool> LoginAsync(LoginCommand command)
        {
            var result = false;
            var user = await _userManager.FindByNameAsync(command.UserName);

            if (user != null)
            {
                var passwordOK = await _userManager.CheckPasswordAsync(user, command.Password);
                if (passwordOK)
                {
                    var signInResult = await _signInManager.PasswordSignInAsync(user, command.Password, command.RememberMe, false);
                    result = signInResult.Succeeded;
                    return result;
                }

            }

            throw new UserDoseNotExistException(command.UserName);



        }

        public async Task<bool> RegisterAsync(RegisterCommand command, string userRole, Guid userId = new Guid())
        {

            var duplicateUser = await _userManager.FindByNameAsync(command.UserName);
            if (duplicateUser != null)
                throw new DuplicateUserNameException(command.UserName);

            var user = TranslateToEntity<RegisterCommand>(command);
            user.DateCreated = DateTime.Now;
            if (userId != Guid.Empty)
            {
                user.CreatorID = userId;
            }
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
        public async Task DeleteUserAsync(Guid userId)
        {

            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                throw new ItemNotFoundException("کاربر ");

            //delete transactions+ bankAccount + planners
            var result1 = await _transcationRepo.DeleteListAsync(x => x.UserId == userId);
            if (result1)
            {
                var result2 = await _planRepo.DeleteListAsync(x => x.UserId == userId);
                if (result2)
                {
                    var result3 = await _bankAccountRepo.DeleteListAsync(x => x.UserId == userId);
                    if (result3)
                    {
                        await _userManager.DeleteAsync(user);
                        return;
                    }

                }



            }
            throw new CodeErrorException();

        }
        public async Task<bool> UpdateUserAsync(RegisterCommand dto, Guid userId,string oldUsername)

        {
            var newUser = TranslateToEntity(dto);
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
                throw new ItemNotFoundException("کاربر ");

            var entity = TranslateToEntity(dto);
            user.DateUpdated = DateTime.Now;
            user.UpdatorID = userId;
            user.Email = newUser.Email;
            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Contains("Member"))
            {
                if(dto.UserName != oldUsername)
                {
                    var duplicateUser = await _userManager.FindByNameAsync(dto.UserName);
                    if (duplicateUser != null)
                        throw new DuplicateUserNameException(dto.UserName);
                    user.UserName = newUser.UserName;
                }
               

            }
            user.DateOfBirth = newUser.DateOfBirth;
            user.FirstName = newUser.FirstName;
            user.LastName = newUser.LastName;
            user.PhoneNumber = newUser.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }
        public async Task<bool> UpdatePasswordAsync(string userName, string password)

        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
                throw new ItemNotFoundException("کاربر ");




            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var changePasswordOK = await _userManager.ResetPasswordAsync(user, token, password);
            return changePasswordOK.Succeeded;


        }

        public async Task<UserResult> TranslateToResultAsync(User entity)
        {
            var dto = entity.Adapt<UserResult>();
            dto.RoleName = (await _userManager.GetRolesAsync(entity))[0];
            return dto;
        }

        public User TranslateToEntity<DTO>(DTO dto)
        {
            return dto.Adapt<User>();
        }
    }

}

