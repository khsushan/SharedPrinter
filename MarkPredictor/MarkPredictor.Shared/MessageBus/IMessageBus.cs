using System;
using System.Collections.Generic;
using System.Text;

namespace MarkPredictor.Shared.MessageBus
{
    public interface IMessageBus
    {
        void Subscribe(Action handler);
        void Unsubscribe(Action handler);
        void Publish(TMessage message);
        void Publish(Object message);
    }
}
