using System;
using moolah.Domain.Models;
using moolah.Domain.Services;
using Xunit;

namespace moolah.Tests
{
    public class PaydayManagerTests
    {
        private readonly Settings _settings = new Settings
        {
            BasePayDay = new DateTime( 2014, 02, 27 ),
            PayInterval = 2,
            IntervalType = PaymentInterval.Weeks
        };

        private readonly DateTime _mockCurrentDate = new DateTime( 2014, 03, 06 );

        [Fact]
        public void GetNextPaydayReturnsCorrrectDate ()
        {
            DateTimeProvider.SetCurrentDateTime( _mockCurrentDate );
            var mgr = new PaydayManager( _settings );
            var expected = new DateTime( 2014, 03, 13 );
            var sut = mgr.GetNextPayday();

            Assert.Equal( sut, expected );
        }

        [Fact]
        public void GetPaydayAfterNextReturnsCorrrectDate ()
        {
            DateTimeProvider.SetCurrentDateTime( _mockCurrentDate );
            var mgr = new PaydayManager( _settings );
            var expected = new DateTime( 2014, 03, 27 );
            var sut = mgr.GetPaydayAfterNext();

            Assert.Equal( sut, expected );
        }

        [Fact]
        public void DaysUntilNextPaydayReturnsCorrectNumber ()
        {
            DateTimeProvider.SetCurrentDateTime( _mockCurrentDate );
            var mgr = new PaydayManager( _settings );
            const int expected = 7;
            var sut = mgr.DaysUntilNextPayday();

            Assert.Equal( sut, expected );
        }

        [Fact]
        public void IsPayDayReturnsTrueForPayday ()
        {
            DateTimeProvider.SetCurrentDateTime( _mockCurrentDate );
            var mgr = new PaydayManager( _settings );
            var realPayDay = new DateTime( 2014, 03, 13 );
            var realPayDay2 = new DateTime( 2014, 03, 27 );

            Assert.True( mgr.IsPayDay( realPayDay ) );
            Assert.True( mgr.IsPayDay( realPayDay2 ) );
        }

        [Fact]
        public void IsPayDayReturnsFalseForNonPayday ()
        {
            DateTimeProvider.SetCurrentDateTime( _mockCurrentDate );
            var mgr = new PaydayManager( _settings );
            var nonPayDay = new DateTime( 2014, 03, 14 );
            var nonPayDay2 = new DateTime( 2014, 03, 26 );

            Assert.False( mgr.IsPayDay( nonPayDay ) );
            Assert.False( mgr.IsPayDay( nonPayDay2 ) );
        }

    }
}
