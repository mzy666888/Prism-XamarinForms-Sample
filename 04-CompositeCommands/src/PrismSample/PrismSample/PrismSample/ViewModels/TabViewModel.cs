using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Mvvm;

namespace PrismSample.ViewModels
{
    public class TabViewModel : BindableBase
    {
        public TabViewModel(IApplicationCommands applicationCommands)
        {
            applicationCommands.SaveCommand.RegisterCommand(SaveCommand);
            applicationCommands.ResetCommand.RegisterCommand(ResetCommand);
        }

        private string _lastSaved;

        public string LastSaved
        {
            get => _lastSaved;
            set => SetProperty(ref _lastSaved, value);
        }

        private DelegateCommand _saveCommand;
        public DelegateCommand SaveCommand => _saveCommand ??= new DelegateCommand(() =>
        {
            LastSaved = DateTime.Now.ToString();
        });

        private DelegateCommand _resetCommand;
        public DelegateCommand ResetCommand => _resetCommand ??= new DelegateCommand(() =>
        {
            LastSaved = "Reset - no value";
        });

    }
}
