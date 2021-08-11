using System;

namespace Countdown.Core.Events
{
    public abstract class DomainEvent
    {
        public Guid EventId { get; private set; }
        public DateTime DateOfEvent { get; private set; }

        protected DomainEvent(DateTime dateOfEvent)
        {
            EventId = Guid.NewGuid();
            DateOfEvent = dateOfEvent;
        }
    }
}
