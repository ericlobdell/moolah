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
    }
}
