using ApplicationDatabaseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomainCore.Abstraction
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<bool> CreateAsync(T item);
        Task<IEnumerable<T>> ReadAsync();
        Task<T> ReadByIdAsync(int id);
        Task<bool> UpdateAsync(int id, T item);
        Task<bool> DeleteAsync(int id);
        DbSet<T> Get();
    }
}
