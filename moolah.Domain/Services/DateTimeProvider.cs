using System;

namespace moolah.Domain.Services
{
    public static class DateTimeProvider
    {
        private static DateTime? _currentDate;
        private static readonly TimeSpan OneSecondTimeSpan = TimeSpan.FromSeconds( 1 );
        /// <summary>
        /// Returns System.DateTime.Now, unless specifically overridden with SetCurrentDateTime
        /// </summary>
        /// <returns></returns>
        public static DateTime GetCurrentDateTime()
        {
            return _currentDate ?? DateTime.Now;
        }
        /// <summary>
        /// Overrides return value for GetCurrentDateTime. 
        /// Use with care, implemented for testing only.
        /// </summary>
        /// <param name="dt"></param>
        public static void SetCurrentDateTime(DateTime dt)
        {
            _currentDate = dt;
        }
        /// <summary>
        /// Undoes any setting from SetCurrentDateTime. 
        /// Restores GetCurrentDateTime's return value to System.DateTime.Now. 
        /// </summary>
        public static void ResetDateTime()
        {
            _currentDate = null;
        }
        /// <summary>
        /// Subtracts date2 from date1, and checks to see if the difference is within the specified tolerance.
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public static bool DatesAreWithinTolerance(DateTime date1, DateTime date2, TimeSpan tolerance)
        {
            return (date1 - date2).Duration() < tolerance;
        }
        /// <summary>
        /// Subtracts date2 from date1, and checks to see if the difference is within one second.
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static bool DatesAreWithinOneSecond ( DateTime date1, DateTime date2 )
        {
            return ( date1 - date2 ).Duration() < OneSecondTimeSpan;
        }

    }
}
