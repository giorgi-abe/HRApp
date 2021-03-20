using ApplicationDatabaseModels.User;
using ApplicationDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomainCore.Abstraction
{
    public interface IUserRepository
    {
        Task<bool> SignInAsync(UserAuthDto userAuthDto);
        Task<bool> RegisterAsync(User item,string password);
        Task<bool> UpdateAsync(string id, User item);
        Task<bool> DeleteAsync(string id);
    }
}
