using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceRegistrationApp.Services
{
    public class ExampleBetaService : IExampleBetaService
    {
        /// <inheritdoc />
        public int NumberValue { get; set; }

        public ExampleBetaService()
        {
            var rnd = new Random();
            NumberValue = rnd.Next(1, 1000);
        }
    }
}
