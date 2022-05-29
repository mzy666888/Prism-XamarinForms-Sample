using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Prism.Events;
using PrismSample.Models;
using PrismSample.Navigation;

namespace PrismSample.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IEventAggregator _eventAggregator;

        public MainPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
            : base(navigationService)
        {
            _eventAggregator = eventAggregator;
            Title = "Prism.Forms EventAggregator";
        }

        private ICommand _localCommand;

        public ICommand LocalCommand
        {
            get => _localCommand = new DelegateCommand(() =>
            {
                NavigationService.NavigateAsync(Navigate.Home);
            });
        }

        private ICommand _nativeCommand;

        public ICommand NativeCommand
        {
            get => _nativeCommand ??= new DelegateCommand(() =>
            {
                _eventAggregator.GetEvent<NativeEvent>().Publish(new NativeEventArgs("Xamarin.Forms"));
            });
        }
    }
}
