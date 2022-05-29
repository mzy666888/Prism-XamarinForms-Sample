using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Prism.Services;

namespace PrismSample.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IPageDialogService _pageDialogService;

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            Title = "Main Page";
        }

        private DelegateCommand _displayAlertCommand;

        public DelegateCommand DisplayAlertCommand
        {
            get => _displayAlertCommand ??= new DelegateCommand(async () =>
            {
                var result = await _pageDialogService.DisplayAlertAsync("Alert",
                    "This is an alert from MainPageViewModel.", "Accept", "Cancel");
                Trace.WriteLine(result);
            });
        }

        private DelegateCommand _displayActionSheetCommand;

        public DelegateCommand DisplayActionSheetCommand
        {
            get => _displayActionSheetCommand ??= new DelegateCommand(async () =>
            {
                var result = await _pageDialogService.DisplayActionSheetAsync("ActionSheet", "Cancel", "Destory",
                    "Option 1", "Option 2");
                Trace.WriteLine(result);
            });
        }

        private DelegateCommand _displayActionSheetUsingActionSheetButtons;

        public DelegateCommand DisplayActionSheetUsingActionSheetButtonsCommand
        {
            get => _displayActionSheetUsingActionSheetButtons ??= new DelegateCommand(async () =>
            {
                var buttons = new IActionSheetButton[]
                {
                    ActionSheetButton.CreateButton("Option 1",WriteLine,"Option 1"),
                    ActionSheetButton.CreateButton("Option 2",WriteLine,"Option 2"),
                    ActionSheetButton.CreateButton("Cancel",WriteLine,"Cancel"),
                    ActionSheetButton.CreateButton("Destroy",WriteLine,"Destroy"),
                };

                await _pageDialogService.DisplayActionSheetAsync("ActionSheet with ActionSheetButtons", buttons);
            });
        }

        private void WriteLine(string obj)
        {
            Trace.WriteLine(obj);
        }
    }
}
