using Countdown.Core.Model;
using FluentAssertions;
using Xunit;

namespace Countdown.Core.UnitTests
{
    public class SubjectTests
    {
        [Fact]
        public void Should_create_subject()
        {
            //Arrange
            var title = TestHelper.GetSomeTitle();
            var totalTime = TestHelper.GetSomeTotalTime();
            //Act
            var sut = new Subject(title, totalTime);
            //Assert
            sut.Title.Should().Be(title);
            sut.TotalTime.Should().Be(totalTime);
        }
    }
}