using App_Profile_Book.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App_Profile_Book.Services.Authentification
{
    public interface IAuthentification
    {
        bool Validation(ProfileModel obj);
    }
}
