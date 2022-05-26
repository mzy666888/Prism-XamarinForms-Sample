using Prism.Commands;
using Prism.Navigation;
using ServiceRegistrationApp.Services;

namespace ServiceRegistrationApp.ViewModels
{
    public class ViewAPageViewModel : ViewModelBase
    {
        private readonly IExampleAlphaService _exampleAlphaService;
        private int _numberValue;

        public int NumberValue
        {
            get => _numberValue;
            set => SetProperty(ref _numberValue, value);
        }
        /// <inheritdoc />
        public ViewAPageViewModel(INavigationService navigationService, IExampleAlphaService exampleAlphaService) : base(navigationService)
        {
            _exampleAlphaService = exampleAlphaService;

            NumberValue = _exampleAlphaService.NumberValue;

        }

        private DelegateCommand _gobackCommand;

        public DelegateCommand GobackCommand
        {
            get => _gobackCommand ??= new DelegateCommand(async () =>
            {
                await NavigationService.GoBackAsync();
            });
        }
    }
}