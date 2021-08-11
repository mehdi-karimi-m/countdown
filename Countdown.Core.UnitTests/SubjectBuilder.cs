using System;
using Countdown.Core.Model;

namespace Countdown.Core.UnitTests
{
    public class SubjectBuilder
    {
        private string _title;
        private TimeSpan _totalTime;
        private IDateTimeService _dateTimeService;

        public SubjectBuilder()
        {
            ResetState();
        }
        private void ResetState()
        {
            _title = TestHelper.GetSomeTitle();
            _totalTime = TestHelper.GetSomeTotalTime();
            _dateTimeService = new DateTimeService();
        }

        public Subject Build()
        {
            var subject = new Subject(_title, _totalTime, _dateTimeService);
            ResetState();
            return subject;
        }

        public SubjectBuilder WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public SubjectBuilder WithTotalTime(TimeSpan totalTime)
        {
            _totalTime = totalTime;
            return this;
        }

        public SubjectBuilder WithDateTimeService(IDateTimeService dateTimeServiceStub)
        {
            _dateTimeService = dateTimeServiceStub;
            return this;
        }
    }
}
