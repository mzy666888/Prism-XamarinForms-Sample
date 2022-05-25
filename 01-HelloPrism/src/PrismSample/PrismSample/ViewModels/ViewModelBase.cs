﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismSample.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
            Title = GetType().Name.Replace("ViewModel", string.Empty);

            GoHomeCommand = new DelegateCommand(OnGoHomeCommandExecuted);
            NavigateCommand = new DelegateCommand<string>(OnNavigateCommandExecuted);
        }

        private IEnumerable<string> _messages;

        public IEnumerable<string> Messages
        {
            get => _messages;
            set => SetProperty(ref _messages, value);
        }

        private int _initializedCount;

        public int InitializedCount
        {
            get => _initializedCount;
            set => SetProperty(ref _initializedCount, value, UpdateMessage);
        }

        private int _onNavigatedFromCount;

        public int OnNavigatedFromCount
        {
            get => _onNavigatedFromCount;
            set => SetProperty(ref _onNavigatedFromCount, value, UpdateMessage);
        }

        private int _onNavigatedToCount;

        public int OnNavigatedToCount
        {
            get => _onNavigatedToCount;
            set => SetProperty(ref _onNavigatedToCount, value, UpdateMessage);
        }

        private void UpdateMessage()
        {
            Messages = new[]
            {
                $"Initalized Called:{InitializedCount} time(s)",
                $"OnNavigatedFrom Called:{OnNavigatedFromCount} time(s)",
                $"OnNavigatedTo Called:{OnNavigatedToCount} time(s)",
            };
        }

        public DelegateCommand GoHomeCommand { get; }

        private async void OnGoHomeCommandExecuted()
        {
            var result = await NavigationService.NavigateAsync("/MainPage");
            if (!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        public DelegateCommand<string> NavigateCommand { get; }

        private async void OnNavigateCommandExecuted(string path)
        {
            var result = await NavigationService.NavigateAsync(path);
            if (!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }
        public virtual void Initialize(INavigationParameters parameters)
        {
            InitializedCount++;
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
            OnNavigatedFromCount++;
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            OnNavigatedToCount++;
        }

        public virtual void Destroy()
        {

        }
    }
}
