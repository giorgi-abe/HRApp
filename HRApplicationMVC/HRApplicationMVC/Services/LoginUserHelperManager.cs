using HRApplicationMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApplicationMVC.Services
{
    public class LoginUserHelperManager
    {
        private static SignedInDto _loginUser = default;
        public static async Task LoginUser(SignedInDto obj) => _loginUser = obj;
        public static async Task LogOutUser() => _loginUser = default;
        public static async Task<SignedInDto> GetCurrentUser() => _loginUser;
    }
}
