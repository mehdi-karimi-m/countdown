using System;
using FizzWare.NBuilder;

namespace Countdown.Core.UnitTests
{
    public static class TestHelper
    {
        private static readonly RandomGenerator Random = new RandomGenerator(Guid.NewGuid().GetHashCode());
        public static string GetSomeTitle()
        {
            return Random.NextString(5, 100);
        }

        public static TimeSpan GetSomeTotalTime()
        {
            return new TimeSpan(Random.UShort(), Random.Next(0, 59), Random.Next(0, 59));
        }
    }
}