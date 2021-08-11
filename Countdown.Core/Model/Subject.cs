using System;
using System.Collections.Generic;
using Countdown.Core.Events;

namespace Countdown.Core.Model
{
    public class Subject
    {
        private readonly IDateTimeService _dateTimeService;
        public string Title { get; private set; }
        public TimeSpan TotalTime { get; private set; }
        private readonly List<object> _events = new();
        private bool _lastEventIsStartedEvent = false;
        private DateTime _from;
        private TimeSpan _elapsedTime = new(0);

        public Subject(string title, TimeSpan totalTime, IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
            Cause(new SubjectCreated(title, totalTime, _dateTimeService.GetNow()));
        }

        public void StartCountdown()
        {
            _events.Add(new CountdownStarted(_dateTimeService.GetNow()));
        }

        public void StopCountdown()
        {
            _events.Add(new CountdownStopped(_dateTimeService.GetNow()));
        }

        public TimeSpan GetTotalTimeLeft()
        {
            return TotalTime - GetElapsedTime(_events, _dateTimeService.GetNow());
        }
        private TimeSpan GetElapsedTime(IList<object> events, DateTime now)
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

        private void Cause(object @event)
        {
            _events.Add(@event);
            Apply(@event);
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
            Title = @event.Title;
            TotalTime = @event.TotalTime;
        }
    }
}
