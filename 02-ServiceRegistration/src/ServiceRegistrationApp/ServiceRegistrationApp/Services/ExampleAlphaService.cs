using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceRegistrationApp.Services
{
    public class ExampleAlphaService : IExampleAlphaService
    {
        /// <inheritdoc />
        public int NumberValue { get; set; }

        public ExampleAlphaService()
        {
            var rnd = new Random();
            NumberValue = rnd.Next(1, 1000);
        }
    }
}
