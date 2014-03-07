using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moolah.Domain.Services
{
    public static class DateTimeProvider
    {
        private static DateTime _currentDate = DateTime.Now;
        private static TimeSpan _tolerance = TimeSpan.FromSeconds( 1 );

        public static DateTime GetCurrentDateTime()
        {
            return _currentDate;
        }

        public static void SetCurrentTime(DateTime dt)
        {
            _currentDate = dt;
        }

        public static void ResetDateTime()
        {
            _currentDate = DateTime.Now;
        }

        public static bool DatesAreWithinTolerance(DateTime date1, DateTime date2, TimeSpan tolerance)
        {
            return (date1 - date2).Duration() < tolerance;
        }

        public static bool DatesAreWithinTolerance ( DateTime date1, DateTime date2 )
        {
            return ( date1 - date2 ).Duration() < _tolerance;
        }

        public static void SetTolerance(TimeSpan tolerance)
        {
            _tolerance = tolerance;
        }
    }
}
