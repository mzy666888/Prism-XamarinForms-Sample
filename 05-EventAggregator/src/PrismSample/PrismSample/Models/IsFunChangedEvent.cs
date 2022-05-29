using System;
using System.Collections.Generic;
using System.Text;
using Prism.Events;

namespace PrismSample.Models
{
    public class IsFunChangedEvent : PubSubEvent<bool>
    {
    }
}
