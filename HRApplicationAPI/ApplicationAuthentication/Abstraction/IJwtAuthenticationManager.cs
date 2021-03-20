using ApplicationDatabaseModels;
using ApplicationDatabaseModels.User;
using ApplicationDomainCore.Abstraction;
using ApplicationDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAuthentication.Abstraction
{
    public interface IJwtAuthenticationManager
    {
        Task<string> AuthenticateAsync(UserAuthDto data);
        void SetUserRepo(IUserRepository usersRepo);
    }
}
