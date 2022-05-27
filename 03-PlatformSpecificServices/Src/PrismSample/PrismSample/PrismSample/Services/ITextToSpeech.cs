using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrismSample.Services
{
    public interface ITextToSpeech
    {
        Task Speak(string text);
    }
}
