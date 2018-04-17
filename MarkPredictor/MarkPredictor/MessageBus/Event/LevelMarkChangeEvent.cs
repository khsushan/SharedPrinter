using MarkPredictor.Dto;
using Prism.Events;

namespace MarkPredictor.MessageBus.Event
{
    public class LevelMarkChangeEvent : PubSubEvent<long>
    {
    }
}
