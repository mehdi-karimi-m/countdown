using System;

namespace Countdown.Core.Events
{
    public class CountdownStopped : DomainEvent
    {
        public DateTime StopDateTime { get; private set; }
        public CountdownStopped(DateTime now) : base(now)
        {
            StopDateTime = now;
        }
    }
}