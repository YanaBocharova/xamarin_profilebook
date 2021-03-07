using Acr.UserDialogs;
using App_Profile_Book.Model;
using App_Profile_Book.Services.ProfileService;
using App_Profile_Book.Services.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App_Profile_Book.Services.Authentification
{
    public class Authentification:IAuthentification
    {

        // private IProfileService repository;
        public Authentification()
        {
           // this.repository = repository;
        }
        public bool Validation(ProfileModel obj)
        {
            var contex = new ValidationContext(obj);
            var validResult = new List<ValidationResult>();
            if (!Validator.TryValidateObject(obj, contex, validResult, true))
            {

                var confirmDial = new ConfirmConfig()
                {
                    Message = "Inccorect login or password",
                    OkText = "Ok",
                    CancelText = "cancel"
                };
                var confirm = UserDialogs.Instance.ConfirmAsync(confirmDial);
                return false;
            }
            return true;
        }
    }
}
