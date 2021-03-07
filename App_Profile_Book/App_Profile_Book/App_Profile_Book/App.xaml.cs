using App_Profile_Book.Services.Authentification;
using App_Profile_Book.Services.Authorization;
using App_Profile_Book.Services.ProfileService;
using App_Profile_Book.Services.Repository;
using App_Profile_Book.Services.Settings;
using App_Profile_Book.View;
using App_Profile_Book.ViewModel;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;

namespace App_Profile_Book
{
    public partial class App : PrismApplication
    {
        public App()
        {
           

        }
        #region --Ovverides--
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Services
            containerRegistry.RegisterInstance<ISettingsManager>(Container.Resolve<SettingsManager>());
            containerRegistry.RegisterInstance<IRepository>(Container.Resolve<Repository>());
            containerRegistry.RegisterInstance<IProfileService>(Container.Resolve<ProfilesService>());
            containerRegistry.RegisterInstance<IAuthentification>(Container.Resolve<Authentification>());
            containerRegistry.RegisterInstance<IAuthorization>(Container.Resolve<Services.Authorization.Authorization>());

            //containerRegistry.RegisterInstance<IValidation>(Container.Resolve<Validation>());


            //Navigation
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainListPage, MainListPageViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<SingInPage, SingInPageViewModel>();
            containerRegistry.RegisterForNavigation<SingUpPage, SingUpPageViewModal>();
            containerRegistry.RegisterForNavigation <SettingsViewPage,SettingsViewPageViewModal>();
            containerRegistry.RegisterForNavigation <AddEditProfilePage, AddEditProfilePageViewModel>();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
           await NavigationService.NavigateAsync("/NavigationPage/MainPage");
            
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        #endregion

    }
}
