using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkPredictor.Shared.MessageBus.Event
{
    public class ModuleLoadEvent : PubSubEvent<string>
    {
    }
}
