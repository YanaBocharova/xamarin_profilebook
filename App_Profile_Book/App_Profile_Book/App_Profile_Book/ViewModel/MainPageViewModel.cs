using App_Profile_Book.Model;
using App_Profile_Book.Services.Authentification;
using App_Profile_Book.Services.ProfileService;
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
    public class MainPageViewModel : BindableBase
    {

        private ISettingsManager settingsManager;
        private IAuthentification authentification;
        private IProfileService profileService;

        private readonly INavigationService navigationService;

        #region --Public properties---
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

        #endregion

        public MainPageViewModel(ISettingsManager settingsManager, INavigationService navigationService, IProfileService profileService)
        {
            this.settingsManager = settingsManager;
            this.navigationService = navigationService;
            this.profileService = profileService;

            authentification = new Authentification();

            Password = settingsManager.password;
            Login = settingsManager.login;
            Title = "MainPage";
            
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnPropertyChanged(args);
            if(args.PropertyName==nameof(Login) )
            {
                settingsManager.login = Login;
            }
            if (args.PropertyName == nameof(Password))
            {
                settingsManager.password = Password;
            }
        }

        public ICommand SingInButtonTapCommand => new Command(OnSingInButtonTapCommand);
        public ICommand ClickCommand => new Command(OnNavigationPage);
       
        private async void OnNavigationPage(object obj)
        {
            await navigationService.NavigateAsync("SingUpPage");
        }

        public async void OnSingInButtonTapCommand(object obj)
        {

            var profile = new ProfileModel()
            {
                Login = login,
                Password = password,
                ConfirmPassword = password,
                Date = DateTime.Now
            };

            // profile.Id = id;
            // ProfileList.Add(profile);

            if (authentification.Validation(profile))
            {
                //await profileService.InsertAsync(profile);
                var item = await profileService.SearchLogin(profile.Login);

                if (item != null)
                {
                    await navigationService.NavigateAsync("MainListPage");
                }
            }
            else
            {
               Login = "";
               Password = "";
            }
          
        }

    }
}

