using System;
using System.Collections.Generic;
using Countdown.Core.Events;

namespace Countdown.Core.Model
{
    internal class ElapsedCalculator
    {
        private bool _lastEventIsStartedEvent = false;
        private DateTime _from;
        private TimeSpan _elapsedTime = new(0);
        public TimeSpan GetElapsedTime(IList<object> events, DateTime now)
        {
            for (var i = 0; i < events.Count; i++)
            {
                Apply(events[i]);
            }

            if (_lastEventIsStartedEvent)
            {
                _elapsedTime += now.Subtract(_from);
            }

            return _elapsedTime;
        }

        private void Apply(object @event)
        {
            When((dynamic)@event);
        }

        private void When(CountdownStarted @event)
        {
            _from = @event.StartedAt;
            _lastEventIsStartedEvent = true;
        }

        private void When(CountdownStopped @event)
        {
            _elapsedTime += @event.StopDateTime.Subtract(_from);
            _lastEventIsStartedEvent = false;
        }

        private void When(SubjectCreated @event)
        {

        }
    }
}