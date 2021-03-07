using System;
using System.Collections.Generic;
using System.Text;

namespace App_Profile_Book.Services.Settings
{
    public interface ISettingsManager
    {
        string login { get; set; }
        string password { get; set; }
    }
}
