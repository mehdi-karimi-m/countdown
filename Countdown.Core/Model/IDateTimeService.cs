using System;

namespace Countdown.Core.Model
{
    public interface IDateTimeService
    {
        DateTime GetNow();
    }

    public class DateTimeService : IDateTimeService
    {
        public DateTime GetNow()
        {
            return DateTime.Now;
        }
    }
}