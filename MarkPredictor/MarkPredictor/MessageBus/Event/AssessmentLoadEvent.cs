
using MarkPredictor.Dto;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkPredictor.MessageBus.Event
{
    public class AssessmentLoadEvent : PubSubEvent<AssessmentDto>
    {
    }
}
