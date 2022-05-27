using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prism.Services;
using PrismSample.Services;

namespace PrismSample.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly ITextToSpeech _textToSpeech;

        public MainPageViewModel(INavigationService navigationService, IDeviceService device, ITextToSpeech textToSpeech)
            : base(navigationService)
        {
            _textToSpeech = textToSpeech;
            Title = "Main Page";
            Text = $"This text will be spoken by {device.RuntimePlatform}";
        }

        private bool _isExecuting;
        public bool IsExecuting
        {
            get => _isExecuting;
            set => SetProperty(ref _isExecuting, value);
        }

        private string _text;
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        private DelegateCommand _speakCommand;

        public DelegateCommand SpeakCommand => _speakCommand ??=
            new DelegateCommand(() => { _textToSpeech.Speak(Text); }, () => !IsExecuting && !string.IsNullOrEmpty(Text))
                .ObservesProperty(() => IsExecuting).ObservesProperty(() => Text);
    }
}
