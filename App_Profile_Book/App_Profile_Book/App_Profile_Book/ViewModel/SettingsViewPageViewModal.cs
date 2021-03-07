using Acr.UserDialogs;
using App_Profile_Book.Model;
using App_Profile_Book.Services.ProfileService;
using App_Profile_Book.View;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App_Profile_Book.ViewModel
{
    public class SettingsViewPageViewModal : BindableBase, IInitializeAsync
    {
        private IProfileService profileService;
       // private INavigationParameters navigateParams;
        private readonly INavigationService navigationService;

        private string title;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
       
        private ProfileModel selectedProfile;
        public ProfileModel SelectedProfile
        {
            get => selectedProfile;
            set => SetProperty(ref selectedProfile, value);
        }

        public SettingsViewPageViewModal(IProfileService profileService, INavigationService navigationService)
        {
            //this.navigateParams = navigateParams;
            this.profileService = profileService;
            this.navigationService = navigationService;
            Title = "SettingsViewPage";
        }


        public ObservableCollection<ProfileModel> profileList;

        public ObservableCollection<ProfileModel> ProfileList
        {
            get => profileList;
            set => SetProperty(ref profileList, value);
        }

        #region --Commands--

        public ICommand ClickCommandEdit => new Command(OnAddProfile);

        public async void OnAddProfile(object obj)
        {
            var navParams = new NavigationParameters();
            navParams.Add("ProfileModel", SelectedProfile);
            await navigationService.NavigateAsync("AddEditProfilePage",navParams);

        }

        public ICommand ClickCommandDelete => new Command(OnCommandDelete);
        private async void OnCommandDelete(object obj)
        {
            if (SelectedProfile != null )
            {
                var configConfirm = new ConfirmConfig()
                {
                    Message = "Delete this profile ?",
                    OkText = "Ok",
                    CancelText = "Not"
                };
                var confirm = await UserDialogs.Instance.ConfirmAsync(configConfirm);
                if (confirm)
                {
                    await profileService.RemoveProfile(SelectedProfile);
                    ProfileList.Remove(SelectedProfile);
                }
            }

        }
        #endregion
        public async Task InitializeAsync(INavigationParameters parameters)
        {

            var profiles = await profileService.GetAll();
            ProfileList = new ObservableCollection<ProfileModel>(profiles);

        }
    }
}
