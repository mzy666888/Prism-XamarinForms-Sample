using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismSample.Services;
using Xamarin.Essentials;

namespace PrismSample.Droid.Services
{
    public class TextToSpeech_Android : ITextToSpeech
    {
        /// <inheritdoc />
        public Task Speak(string text)
        {
            return TextToSpeech.SpeakAsync(text);
        }
    }
}