using App_Profile_Book.Model;
using App_Profile_Book.Services.Authorization;
using App_Profile_Book.Services.Repository;
using App_Profile_Book.Services.Settings;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace App_Profile_Book.ViewModel
{
    public class SingUpPageViewModal : BindableBase
    {

        private ISettingsManager settingsManager;
        private IAuthorization authentification;
        private IRepository profileService;

        private readonly INavigationService navigationService;


        private string title;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        public string login;
        public string Login
        {
            get => login;
            set => SetProperty(ref login, value);
        }
        public string password;
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
        public string confirmPassword;
        public string ConfirmPassword
        {
            get => confirmPassword;
            set => SetProperty(ref confirmPassword, value);
        }
        public SingUpPageViewModal(ISettingsManager settingsManager, INavigationService navigationService, IRepository profileService)
        {
            this.settingsManager = settingsManager;
            this.navigationService = navigationService;
            this.profileService = profileService;
            authentification = new Authorization();
           
            Title = "SingUpPage";
        }

        #region --Ovverides--

        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnPropertyChanged(args);

            if ((args.PropertyName == nameof(Login))  ||(args.PropertyName == nameof(Password)) )
            {
                settingsManager.login = Login;
                settingsManager.password = Password;
            }
            //if (args.PropertyName == nameof(Password))
            //{
            //    settingsManager.password = Password;
            //}
        }

        #endregion

        public ICommand SingInButtonTapCommand => new Command(OnSingInButtonTapCommand);
      
        public async void OnSingInButtonTapCommand(object obj)
        {
            var profile = new ProfileModel()
            {
                Login = login,
                Password = password,
                ConfirmPassword=confirmPassword,
                Date = DateTime.Now
            };

            // profile.Id = id;
            // ProfileList.Add(profile);

            if (authentification.Validation(profile))
            {
                await profileService.InsertAsync(profile);
                await navigationService.NavigateAsync("MainListPage");

            }
            else
            {
                Login = "";
                Password = "";
                ConfirmPassword = "";
            }

        }

    }
}

