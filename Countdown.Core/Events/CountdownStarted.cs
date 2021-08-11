using System;

namespace Countdown.Core.Events
{
    public class CountdownStarted : DomainEvent
    {
        public DateTime StartedAt { get; private set; }

        public CountdownStarted(DateTime now) : base(now)
        {
            StartedAt = now;
        }
    }
}