using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkPredictor.Shared.MessageBus
{
    public class CompositeEvent<TPayload> : EventBase
    {
        //public SubscriptionToken Subscribe(Action<TPayload> action);
        //public SubscriptionToken Subscribe(Action<TPayload> action,
        //       ThreadOption threadOption);
        //public virtual SubscriptionToken Subscribe(Action<TPayload> action,
        //      ThreadOption threadOption, bool keepSubscriberReferenceAlive,
        //      Predicate<TPayload> filter);
        //public virtual void Publish(TPayload payload);
        //public virtual void Unsubscribe(Action<TPayload> subscriber);
        //public virtual void Unsubscribe(SubscriptionToken token);
    }
}
