using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;

namespace PrismSample
{
    public interface IApplicationCommands
    {
        CompositeCommand SaveCommand { get; }
        CompositeCommand ResetCommand { get; }
    }
    public class ApplicationCommands : IApplicationCommands
    {
        private CompositeCommand _saveCommand;
        /// <inheritdoc />
        public CompositeCommand SaveCommand => _saveCommand ??= new CompositeCommand();

        private CompositeCommand _resetCommand;

        /// <inheritdoc />
        public CompositeCommand ResetCommand => _resetCommand ??= new CompositeCommand();
    }
}
