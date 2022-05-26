using Prism;
using Prism.Ioc;
using ServiceRegistrationApp.Services;
using ServiceRegistrationApp.ViewModels;
using ServiceRegistrationApp.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace ServiceRegistrationApp
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewAPage, ViewAPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewBPage, ViewBPageViewModel>();

            containerRegistry.RegisterSingleton<IExampleAlphaService, ExampleAlphaService>();

            containerRegistry.Register<IExampleBetaService, ExampleBetaService>();
        }
    }
}
