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
    public class DataEntryPageEventModel : ViewModelBase
    {
        private readonly IEventAggregator _eventAggregator;

        /// <inheritdoc />
        public DataEntryPageEventModel(INavigationService navigationService, IEventAggregator eventAggregator) : base(navigationService)
        {
            _eventAggregator = eventAggregator;

            Title = "So what do you think";

        }

        private bool _isFun;

        public bool IsFun
        {
            get => _isFun;
            set => SetProperty(ref _isFun, value, () => _eventAggregator.GetEvent<IsFunChangedEvent>().Publish(value));
        }

        private ICommand _submitCommand;

        public ICommand SubmitCommand
        {
            get => _submitCommand ??= new DelegateCommand(() => NavigationService.GoBackAsync());
        }

        /// <inheritdoc />
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey(NavigationParameterKeys.CurrentIsFunValue))
            {
                IsFun = parameters.GetValue<bool>(NavigationParameterKeys.CurrentIsFunValue);
            }
        }
    }
}
