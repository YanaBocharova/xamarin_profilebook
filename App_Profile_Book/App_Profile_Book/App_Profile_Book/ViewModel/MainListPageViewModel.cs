using App_Profile_Book.Model;
using App_Profile_Book.Services.Authorization;
using App_Profile_Book.Services.ProfileService;
using App_Profile_Book.Services.Repository;
using App_Profile_Book.Services.Settings;
using App_Profile_Book.View;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Navigation.Xaml;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App_Profile_Book.ViewModel
{
    public class MainListPageViewModel:BindableBase,IInitializeAsync
    {
        private IProfileService profileService ;
        private readonly INavigationService navigationService;

        #region--Public Properties---
        private string title;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
     
        public ObservableCollection<ProfileModel> profileList;

        public ObservableCollection<ProfileModel> ProfileList
        {
            get => profileList;
            set => SetProperty(ref profileList, value);
        }
#endregion

        public MainListPageViewModel(IProfileService profileService, INavigationService navigationService)
        {
            this.profileService = profileService;
            this.navigationService = navigationService;
            Title = "MainListPage";
        }
        #region --Commands--
        public ICommand ClickCommandLogout => new Command(OnNavigationPageLogout);

        private async void OnNavigationPageLogout(object obj)
        {
            await navigationService.NavigateAsync("MainPage");
        }
        public ICommand ClickCommandSettings => new Command(OnNavigationPageSettings);

        private async void OnNavigationPageSettings(object obj)
        {
            await navigationService.NavigateAsync("SettingsViewPage");
        }
        public ICommand AddButtonTabCommand => new Command(OnAddProfile);

        private async void OnAddProfile(object obj)
        {
            await navigationService.NavigateAsync("AddEditProfilePage");
        }
        #endregion

        public async Task InitializeAsync(INavigationParameters parameters)
        {

            var profiles = await profileService.GetAll();
            ProfileList = new ObservableCollection<ProfileModel>(profiles);
          
        }
    }
}
