using App_Profile_Book.Model;
using App_Profile_Book.Services.ProfileService;
using Prism.Mvvm;
using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;

namespace App_Profile_Book.ViewModel
{
    public class AddEditProfilePageViewModel : BindableBase,INavigationAware
    {

        private INavigationService navigateService;
        private IProfileService profileService;
        private string title;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

      
        private ProfileModel editProfile;
        public ProfileModel EditProfile
        {
            get => editProfile;
            set => SetProperty(ref editProfile, value);
        }
 
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new System.NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {

            if (parameters.ContainsKey("ProfileModel"))
            {
                EditProfile = parameters["ProfileModel"] as ProfileModel;
            }
        }

        public AddEditProfilePageViewModel(INavigationService navigateService,IProfileService profileService)
        {
            this.profileService = profileService;
            this.navigateService = navigateService;
            Title = " AddEditProfilePage";
        }

        public ICommand ONButtonSaveCommand => new Command(OnButtonTapSaveCommand);

        //private async void OnNavigationPage(object obj)
        //{
        //    await navigationService.NavigateAsync("SingUpPage");
        //}

        public  async void OnButtonTapSaveCommand(object obj)
        {

             profileService.UpdateProfile(EditProfile);
            
             navigateService.NavigateAsync("SettingsViewPage");

        }

    }
}
