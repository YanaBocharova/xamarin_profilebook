using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App_Profile_Book.Services.Settings
{
    public class SettingsManager:ISettingsManager
    {
        public string login
        {
            get => Preferences.Get(nameof(login), "");
            set => Preferences.Set(nameof(login), value);
        }
        public string password
        {
            get => Preferences.Get(nameof(password) ,"");
            set => Preferences.Set(nameof(password), value);
        }

   
    }
}
