﻿using System;
using moolah.Domain.Models;

namespace moolah.Domain.Services
{
    public class PaydayManager
    {
        private const int DaysInWeek = 7;

        private readonly Settings _config;
        private readonly DateTime _currentDate;
       // private readonly ConfigManager _repo = new ConfigManager();

        public DateTime PreviousPayday { get; set; }
        public DateTime NextPayday { get; set; }

        public PaydayManager (Settings config)
        {
            _config = config;
            _currentDate = DateTimeProvider.GetCurrentDateTime();
        }
        public DateTime GetNextPayday ()
        {
            return _currentDate.AddDays( DaysUntilNextPayday() );
        }

        public int DaysUntilNextPayday ()
        {
            var dayCount = 0;
            var today = _currentDate;
            Func<DateTime, int> getDayCount = null;

            getDayCount = date =>
            {
                if ( IsPayDay( date ) ) 
                    return dayCount;

                dayCount++;
                return getDayCount( date.AddDays( 1 ) );
            };

            return getDayCount( today );
        }

        public DateTime GetPaydayAfterNext ()
        {
            return GetNextPayday().AddDays( DaysInWeek * _config.PayInterval );
        }

        public bool IsPayDay ( DateTime date )
        {
            var days = ( date.Date - _config.BasePayDay.Date ).TotalDays;
            var numWeeks = days / DaysInWeek;
            return ( numWeeks % _config.PayInterval ) == 0;
        }
    }
}
