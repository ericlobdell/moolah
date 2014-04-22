using System;
using moolah.Domain.Services;
using Xunit;

namespace moolah.Tests
{
    public class DateTimeProviderTests : IDisposable
    {

        private readonly TimeSpan _oneSecondTolerance = TimeSpan.FromSeconds(1);
        private readonly TimeSpan _threeSecondTolerance = TimeSpan.FromSeconds( 3 );

        [Fact]
        public void DatesAreWithinToleranceReturnsCorrectValueWhenTrue()
        {
            var baseDateTime = new DateTime(2014, 03, 03);
            var dateWithinToleranceRange = baseDateTime.AddMilliseconds(500);

            var sut = DateTimeProvider.DatesAreWithinTolerance(baseDateTime, dateWithinToleranceRange, _oneSecondTolerance);

            Assert.True(sut);

        }

        [Fact]
        public void DatesAreWithinToleranceReturnsCorrectValueWhenFalse ()
        {
            var baseDateTime = new DateTime( 2014, 03, 03 );
            var dateOutOfToleranceRange = baseDateTime.AddSeconds( 2 );

            var sut = DateTimeProvider.DatesAreWithinTolerance( baseDateTime, dateOutOfToleranceRange, _oneSecondTolerance );

            Assert.False( sut );
        }

        [Fact]
        public void DatesAreWithinOneSecondReturnsCorrectValueWhenTrue ()
        {
            var baseDateTime = new DateTime( 2014, 03, 03 );
            var dateWithinToleranceRange = baseDateTime.AddMilliseconds( 500 );
            var sut = DateTimeProvider.DatesAreWithinOneSecond( baseDateTime, dateWithinToleranceRange);

            Assert.True( sut );
        }

        [Fact]
        public void DatesAreWithinOneSecondReturnsCorrectValueWhenFalse ()
        {
            var baseDateTime = new DateTime( 2014, 03, 03 );
            var dateNotWithinToleranceRange = baseDateTime.AddSeconds(2);
            var sut = DateTimeProvider.DatesAreWithinOneSecond( baseDateTime, dateNotWithinToleranceRange );

            Assert.False( sut );
        }
        
        [Fact]
        public void GetCurrentDateTimeReturnsSystemNowDateByDefault()
        {
            var currentSetDateTime = DateTimeProvider.GetCurrentDateTime();
            var systemNow = DateTime.Now;
            var sut = DateTimeProvider.DatesAreWithinTolerance(currentSetDateTime, systemNow, _threeSecondTolerance);
            Assert.True(sut);
        }

        [Fact]
        public void SetCurrentTimeEffectsReturnValeuForGetCurrentTime()
        {
            var expected = new DateTime(2014, 03, 10);
            DateTimeProvider.SetCurrentDateTime(expected);
            var sut = DateTimeProvider.GetCurrentDateTime();

            Assert.True( DateTimeProvider.DatesAreWithinOneSecond( sut, expected ) );
        }

        [Fact]
        public void ResetDateTimeSetsGetCurrentDateTimeToSystemNow()
        {
            var newDateTimeNow = new DateTime(2014, 10, 10);
            DateTimeProvider.SetCurrentDateTime(newDateTimeNow);
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
