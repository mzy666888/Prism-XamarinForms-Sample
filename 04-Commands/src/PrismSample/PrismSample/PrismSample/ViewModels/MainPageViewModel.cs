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
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }

        private bool _isActive;

        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

        private string _text;

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        private DelegateCommand<string> _buttonClickCommand;

        public DelegateCommand<string> ButtonClickCommand =>
            _buttonClickCommand ??= new DelegateCommand<string>((parameter) =>
            {
                Text = parameter;
            }).ObservesCanExecute(() => IsActive);
    }
}
