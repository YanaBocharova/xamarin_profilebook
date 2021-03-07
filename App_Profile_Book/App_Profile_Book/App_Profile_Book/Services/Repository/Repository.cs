using App_Profile_Book.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App_Profile_Book.Services.Repository
{
    public class Repository:IRepository
    {
        private Lazy<SQLiteAsyncConnection> _database;

        public Repository()
        {
            _database = new Lazy<SQLiteAsyncConnection>(() =>
            {

                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "profilebook.db3");
                var database = new SQLiteAsyncConnection(path);
               // database.DeleteAllAsync<ProfileModel>();
                database.CreateTableAsync<ProfileModel>();
                return database;
            });
        }
        public virtual Task<int> DeleteAsync<T>(T entity) where T : IBaseEntity, new()
        {
            return _database.Value.DeleteAsync(entity);
        }

        public virtual Task<List<T>> GetAllAsync<T>() where T : IBaseEntity, new()
        {
            return _database.Value.Table<T>().ToListAsync();
        }

        public Task<List<T>> GetAllAsync<T>(Expression<Func<T, bool>> predicate) where T : class, new()
        {
            return _database.Value.Table<T>().Where(predicate).ToListAsync();
        }


        public Task<T> GetAsync<T>(Expression<Func<T, bool>> predicate) where T : class, new()
        {
            return  _database.Value.Table<T>().FirstOrDefaultAsync(predicate);
        }

        public Task<ProfileModel> GetAsync(string login)
        {
            return _database.Value.Table<ProfileModel>().FirstOrDefaultAsync(item => item.Login == login);
        }

    public virtual Task<int> InsertAsync<T>(T entity) where T : IBaseEntity, new()
        {
            return _database.Value.InsertAsync(entity);
        }

        public virtual Task<int> UpdateAsync<T>(T entity) where T : IBaseEntity, new()
        {
            return _database.Value.UpdateAsync(entity);
        }
    }
}
