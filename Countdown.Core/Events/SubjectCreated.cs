using System;

namespace Countdown.Core.Events
{
    public class SubjectCreated : DomainEvent
    {
        public string Title { get; private set; }
        public TimeSpan TotalTime { get; private set; }

        public SubjectCreated(string title, TimeSpan totalTime, DateTime dateOfEvent) : base(dateOfEvent)
        {
            Title = title;
            TotalTime = totalTime;
        }
    }
}