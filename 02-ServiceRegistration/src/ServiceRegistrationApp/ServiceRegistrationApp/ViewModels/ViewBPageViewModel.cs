using Prism.Commands;
using Prism.Navigation;
using ServiceRegistrationApp.Services;

namespace ServiceRegistrationApp.ViewModels
{
    public class ViewBPageViewModel : ViewModelBase
    {
        private readonly IExampleBetaService _exampleBetaService;
        private int _numberValue;

        public int NumberValue
        {
            get => _numberValue;
            set => SetProperty(ref _numberValue, value);
        }
        /// <inheritdoc />
        public ViewBPageViewModel(INavigationService navigationService, IExampleBetaService exampleBetaService) : base(navigationService)
        {
            _exampleBetaService = exampleBetaService;
            NumberValue = _exampleBetaService.NumberValue;

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