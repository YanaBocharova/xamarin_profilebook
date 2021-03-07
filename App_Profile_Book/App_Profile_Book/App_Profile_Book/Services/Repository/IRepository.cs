using App_Profile_Book.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App_Profile_Book.Services.Repository
{
    public interface IRepository
    {
        Task<int> InsertAsync<T>(T entity) where T : IBaseEntity, new();
        Task<int> UpdateAsync<T>(T entity) where T : IBaseEntity, new();
        Task<int> DeleteAsync<T>(T entity) where T : IBaseEntity, new();
        Task<List<T>> GetAllAsync<T>() where T : IBaseEntity, new();
        Task<ProfileModel> GetAsync(string login);
        Task<List<T>> GetAllAsync<T>(Expression<Func<T, bool>> predicate ) where T : class, new();
        Task<T> GetAsync<T>(Expression<Func<T, bool>> predicate) where T:class,new();
    }
}
