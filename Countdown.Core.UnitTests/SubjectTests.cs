using System;
using Countdown.Core.Model;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Countdown.Core.UnitTests
{
    public class SubjectTests
    {
        private readonly SubjectBuilder _subjectBuilder;

        public SubjectTests()
        {
            _subjectBuilder = new SubjectBuilder();
        }

        [Fact]
        public void Should_create_subject()
        {
            //Arrange
            var title = TestHelper.GetSomeTitle();
            var totalTime = TestHelper.GetSomeTotalTime();
            //Act
            var sut = _subjectBuilder.WithTitle(title).WithTotalTime(totalTime).Build();
            //Assert
            sut.Title.Should().Be(title);
            sut.TotalTime.Should().Be(totalTime);
        }

        [Fact]
        public void Should_return_total_time_left()
        {
            //Arrange
            var totalTime = TestHelper.GetSomeTotalTime();
            var sut = _subjectBuilder.WithTotalTime(totalTime).Build();
            //Act
            var actualTotalTime = sut.GetTotalTimeLeft();
            //Assert
            actualTotalTime.Should().Be(totalTime);
        }

        [Fact]
        public void
            After_three_minutes_GetTotalTimeLeft_should_return_five_minutes_when_total_time_sets_to_eight_minutes()
        {
            //Arrange
            var dateTimeServiceStub = Substitute.For<IDateTimeService>();
            var dateTimeNow = new DateTime(2021, 8, 10, 9, 10, 0);
            dateTimeServiceStub.GetNow().Returns(dateTimeNow);
            var sut = _subjectBuilder
                .WithDateTimeService(dateTimeServiceStub)
                .WithTotalTime(new TimeSpan(0, 8, 0))
                .Build();
            var threeMinutesLater = dateTimeNow.AddMinutes(3);
            var expectedTotalTimeLeft = new TimeSpan(0, 5, 0);
            //Act
            sut.StartCountdown();
            dateTimeServiceStub.GetNow().Returns(threeMinutesLater);
            var totalTimeLeft = sut.GetTotalTimeLeft();
            //Assert
            totalTimeLeft.Should().Be(expectedTotalTimeLeft);
        }

        [Fact]
        public void After_thirty_minutes_GetTotalTimeLeft_should_return_fifty_minutes()
        {
            //Arrange
            var dateTimeServiceStub = Substitute.For<IDateTimeService>();
            dateTimeServiceStub.GetNow().Returns(new DateTime(2021, 8, 10, 9, 10, 0));
            var sut = _subjectBuilder
                .WithDateTimeService(dateTimeServiceStub)
                .WithTotalTime(new TimeSpan(0, 45, 0))
                .Build();
            //Act
            dateTimeServiceStub.GetNow().Returns(new DateTime(2021, 8, 10, 12, 5, 0));
            sut.StartCountdown();
            dateTimeServiceStub.GetNow().Returns(new DateTime(2021, 8, 10, 12, 15, 0));
            sut.StopCountdown();
            dateTimeServiceStub.GetNow().Returns(new DateTime(2021, 8, 11, 8, 20, 0));
            sut.StartCountdown();
            dateTimeServiceStub.GetNow().Returns(new DateTime(2021, 8, 11, 8, 25, 0));
            sut.StopCountdown();
            dateTimeServiceStub.GetNow().Returns(new DateTime(2021, 8, 12, 18, 50, 0));
            sut.StartCountdown();
            dateTimeServiceStub.GetNow().Returns(new DateTime(2021, 8, 12, 19, 5, 0));
            sut.StopCountdown();
            var totalTimeLeft = sut.GetTotalTimeLeft();
            //Assert
            totalTimeLeft.Should().Be(new TimeSpan(0, 15, 0));
        }
    }
}