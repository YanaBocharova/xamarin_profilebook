using App_Profile_Book.Model;
using App_Profile_Book.Services.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace App_Profile_Book.Services.ProfileService
{
    public class ProfilesService :Repository.Repository,IProfileService
    {
        IRepository repository;
        public ProfilesService()
        {
            repository = new Repository.Repository();
        }

        public Task<int> AddProfile(ProfileModel item)
        {
            var id=repository.InsertAsync<ProfileModel>(item);
            return id;
        }

        public Task<List<ProfileModel>> GetAll()
        {
            return repository.GetAllAsync<ProfileModel>();
        }

        public Task<int> RemoveProfile(ProfileModel item)
        {
           var id= repository.DeleteAsync<ProfileModel>(item);
            return id;
        }

        public Task<ProfileModel> SearchLogin(string login)
        {
            return repository.GetAsync(login);
        }

        public void UpdateProfile(ProfileModel item)
        {
            repository.UpdateAsync<ProfileModel>(item);
        }
    }
}
