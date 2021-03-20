using ApplicationDatabaseModels.User;
using ApplicationDomainCore.Abstraction;
using ApplicationDtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomainCore
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager = default;
        private readonly SignInManager<User> _signInManager = default;
        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<bool> SignInAsync(UserAuthDto userAuthDto)
        {
            var User = await _userManager.FindByNameAsync(userAuthDto.Username);
            var Result = await _signInManager.PasswordSignInAsync(User, userAuthDto.Password, false, false);
            return Result.Succeeded;
        }

        public async Task<bool> DeleteAsync(string Username)
        {
            var item = await _userManager.FindByNameAsync(Username);
            var result = await _userManager.DeleteAsync(item);
            return result.Succeeded;
        }

        public async Task<bool> RegisterAsync(User user, string password)
        {
            var Result = await _userManager.CreateAsync(user, password);
            return Result.Succeeded;
        }

        public async Task<bool> UpdateAsync(string Username, User user)
        {
            var item = await _userManager.FindByNameAsync(Username);
            user.Id = item.Id;
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }
    }
}
