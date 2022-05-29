using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using PrismSample.Models;
using PrismSample.Navigation;

namespace PrismSample.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly IEventAggregator _eventAggregator;

        /// <inheritdoc />
        public HomePageViewModel(INavigationService navigationService, IEventAggregator eventAggregator) : base(
            navigationService)
        {
            _eventAggregator = eventAggregator;

            Title = "Your Feedback (Read Only)";

            _eventAggregator.GetEvent<IsFunChangedEvent>().Subscribe(IsFunChanged);
        }

        private void IsFunChanged(bool isFun)
        {
            IsFun = isFun;
        }

        private bool _isFun;

        public bool IsFun
        {
            get => _isFun;
            set => SetProperty(ref _isFun, value);
        }

        private ICommand _entryCommand;

        public ICommand EntryCommand
        {
            get => _entryCommand ??= new DelegateCommand(() =>
                NavigationService.NavigateAsync(Navigate.DataEntry,
                    (NavigationParameterKeys.CurrentIsFunValue, IsFun)));
        }

        private ICommand _goBackCommand;

        public ICommand GoBackCommand
        {
            get => _goBackCommand ??= new DelegateCommand(() => NavigationService.GoBackAsync());
        }

        /// <inheritdoc />
        public override void Destroy()
        {
            _eventAggregator.GetEvent<IsFunChangedEvent>().Unsubscribe(IsFunChanged);
        }
    }
}
