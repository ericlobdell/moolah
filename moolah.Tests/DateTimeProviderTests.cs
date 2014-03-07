using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using moolah.Domain.Services;
using Xunit;

namespace moolah.Tests
{
    public class DateTimeProviderTests : IDisposable
    {

        private readonly TimeSpan _tolerance = TimeSpan.FromSeconds(1);

        [Fact]
        public void DatesAreWithinToleranceReturnsCorrectValueWhenTrue()
        {
            var baseDateTime = new DateTime(2014, 03, 03);
            var dateWithinToleranceRange = baseDateTime.AddMilliseconds(500);

            var shouldBeTrue = DateTimeProvider.DatesAreWithinTolerance(baseDateTime, dateWithinToleranceRange, _tolerance);

            Assert.True(shouldBeTrue);

        }

        [Fact]
        public void DatesAreWithinToleranceReturnsCorrectValueWhenFalse ()
        {
            var baseDateTime = new DateTime( 2014, 03, 03 );
            var dateOutOfToleranceRange = baseDateTime.AddSeconds( 2 );

            var shouldBeFalse = DateTimeProvider.DatesAreWithinTolerance( baseDateTime, dateOutOfToleranceRange, _tolerance );

            Assert.False( shouldBeFalse );
        }

        [Fact]
        public void DatesAreWithinToleranceUseDefaultValueWhenNoToleranceSpecified ()
        {
            var baseDateTime = new DateTime( 2014, 03, 03 );
            var dateWithinToleranceRange = baseDateTime.AddMilliseconds( 500 );
            var shouldBeTrue = DateTimeProvider.DatesAreWithinTolerance( baseDateTime, dateWithinToleranceRange);

            Assert.True( shouldBeTrue );
        }
        
        [Fact]
        public void GetCurrentDateTimeReturnsSystemNowDateByDefault()
        {
            var shouldBeTrue = DateTimeProvider.DatesAreWithinTolerance(DateTimeProvider.GetCurrentDateTime(), DateTime.Now);
            Assert.True(shouldBeTrue);
        }

        [Fact]
        public void SetCurrentTimeEffectsReturnValeuForGetCurrentTime()
        {
            var expected = new DateTime(2014, 03, 10);
            DateTimeProvider.SetCurrentTime(expected);
            var sut = DateTimeProvider.GetCurrentDateTime();

            Assert.True( DateTimeProvider.DatesAreWithinTolerance (sut, expected, _tolerance) );
        }

        [Fact]
        public void ResetDateTimeSetsCurrentDateTimeToSystemNow()
        {
            var newDateTimeNow = new DateTime(2014, 10, 10);
            DateTimeProvider.SetCurrentTime(newDateTimeNow);
            Assert.Equal(DateTimeProvider.GetCurrentDateTime().Date, newDateTimeNow);
            DateTimeProvider.ResetDateTime();
            Assert.Equal( DateTimeProvider.GetCurrentDateTime().Date, DateTime.Now.Date );
        }

        public void Dispose()
        {
            DateTimeProvider.ResetDateTime();
        }

    }
}
