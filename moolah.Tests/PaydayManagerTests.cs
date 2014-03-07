using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using moolah.Domain.Models;
using moolah.Domain.Services;
using Xunit;

namespace moolah.Tests
{
    public class PaydayManagerTests
    {
        private Settings config = new Settings
        {
            BasePayDay = new DateTime( 2014, 02, 27 ),
            PayInterval = 2,
            IntervalType = PaymentInterval.Weeks
        };

        private readonly DateTime _mockCurrentDate = new DateTime( 2014, 03, 06 );

        [Fact]
        public void GetNextPaydayReturnsCorrrectDate ()
        {
            DateTimeProvider.SetCurrentTime( _mockCurrentDate );
            var mgr = new PaydayManager( config );
            var expected = new DateTime( 2014, 03, 13 );
            var sut = mgr.GetNextPayday();

            Assert.Equal( sut, expected );
        }

        [Fact]
        public void GetPaydayAfterNextReturnsCorrrectDate ()
        {
            DateTimeProvider.SetCurrentTime( _mockCurrentDate );
            var mgr = new PaydayManager( config );
            var expected = new DateTime( 2014, 03, 27 );
            var sut = mgr.GetPaydayAfterNext();

            Assert.Equal( sut, expected );
        }

        [Fact]
        public void DaysUntilNextPaydayReturnsCorrectNumber ()
        {
            DateTimeProvider.SetCurrentTime( _mockCurrentDate );
            var mgr = new PaydayManager( config );
            const int expected = 7;
            var sut = mgr.DaysUntilNextPayday();

            Assert.Equal( sut, expected );
        }

        [Fact]
        public void IsPayDayReturnsTrueForPayday ()
        {
            DateTimeProvider.SetCurrentTime( _mockCurrentDate );
            var mgr = new PaydayManager( config );
            var realPayDay = new DateTime( 2014, 03, 13 );
            var realPayDay2 = new DateTime( 2014, 03, 27 );

            Assert.True( mgr.IsPayDay( realPayDay ) );
            Assert.True( mgr.IsPayDay( realPayDay2 ) );
        }

        [Fact]
        public void IsPayDayReturnsFalseForNonPayday ()
        {
            DateTimeProvider.SetCurrentTime( _mockCurrentDate );
            var mgr = new PaydayManager( config );
            var nonPayDay = new DateTime( 2014, 03, 14 );
            var nonPayDay2 = new DateTime( 2014, 03, 26 );

            Assert.False( mgr.IsPayDay( nonPayDay ) );
            Assert.False( mgr.IsPayDay( nonPayDay2 ) );
        }

    }
}
