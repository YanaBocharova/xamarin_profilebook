using Acr.UserDialogs;
using App_Profile_Book.Model;
using App_Profile_Book.Services.ProfileService;
using App_Profile_Book.Services.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace App_Profile_Book.Services.Authorization
{
    public class Authorization : IAuthorization
    {
        public Authorization()
        {
        }
        public bool   Validation(ProfileModel obj)
        {
            var contex = new ValidationContext(obj);
            var validResult = new List<ValidationResult>();
           if(!Validator.TryValidateObject(obj,contex,validResult,true))
            {
                
                var confirmDial = new ConfirmConfig()
                { 
                   Message= validResult[0].ErrorMessage,
                   OkText="Ok",
                   CancelText="cancel"
                };
              var confirm = UserDialogs.Instance.ConfirmAsync(confirmDial);
              return false;
            }
            return true;
        }
    }
}
