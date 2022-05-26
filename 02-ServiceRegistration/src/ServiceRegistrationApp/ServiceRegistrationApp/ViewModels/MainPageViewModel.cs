using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceRegistrationApp.Views;

namespace ServiceRegistrationApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }

        private DelegateCommand _goToViewACommand;

        public DelegateCommand GoToViewACommand
        {
            get => _goToViewACommand ??= new DelegateCommand(async () =>
            {
                await NavigationService.NavigateAsync(nameof(ViewAPage));
            });
        }

        private DelegateCommand _goToViewBCommand;

        public DelegateCommand GoToViewBCommand
        {
            get => _goToViewBCommand ??= new DelegateCommand(async () =>
            {
                await NavigationService.NavigateAsync(nameof(ViewBPage));
            });
        }
    }
}
