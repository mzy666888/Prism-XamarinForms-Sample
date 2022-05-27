using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrismSample.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private IApplicationCommands _applicationCommands;
        public IApplicationCommands ApplicationCommands
        {
            get => _applicationCommands;
            set => SetProperty(ref _applicationCommands, value);
        }

        public MainPageViewModel(INavigationService navigationService, IApplicationCommands applicationCommands)
            : base(navigationService)
        {
            ApplicationCommands = applicationCommands;
            Title = "Main Page";
        }
    }
}
