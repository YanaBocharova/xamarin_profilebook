using App_Profile_Book.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace App_Profile_Book.Services.ProfileService
{
    public interface IProfileService
    {
       Task<List<ProfileModel>> GetAll();
       Task<int> AddProfile(ProfileModel item);
       Task<ProfileModel> SearchLogin(string  login);
       Task<int>  RemoveProfile(ProfileModel item);
       void UpdateProfile(ProfileModel item);
    }
}
