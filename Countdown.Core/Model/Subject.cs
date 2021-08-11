using System;

namespace Countdown.Core.Model
{
    public class Subject
    {
        public string Title { get; private set; }
        public TimeSpan TotalTime { get; private set; }

        public Subject(string title, TimeSpan totalTime)
        {
            Title = title;
            TotalTime = totalTime;
        }

        public void StartCountdown()
        {

        }
    }
}
