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

        [Fact]
        public void GetCurrentDateTimeReturnsSystemNowDateByDefault()
        {
            Assert.Equal(DateTimeProvider.GetCurrentDateTime().Date, DateTime.Now.Date);
        }

        [Fact]
        public void SetCurrentTimeEffectsReturnValeuForGetCurrentTime()
        {
            var expected = new DateTime(2014, 03, 10);
            DateTimeProvider.SetCurrentTime(expected);
            var sut = DateTimeProvider.GetCurrentDateTime().Date;

            Assert.Equal(sut, expected);
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
