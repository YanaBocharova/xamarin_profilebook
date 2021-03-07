using App_Profile_Book.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App_Profile_Book.Services.Authorization
{
    public interface IAuthorization
    {
       bool Validation(ProfileModel obj);
    }
}
