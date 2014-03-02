using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using moolah.Domain.Models;

namespace moolah.Domain.Services
{
    public class PaydayManager
    {
        private const int DaysInWeek = 7;

        private readonly Settings _config;
       // private readonly ConfigManager _repo = new ConfigManager();

        public DateTime PreviousPayday { get; set; }
        public DateTime NextPayday { get; set; }

        public PaydayManager ()
        {
    //        _config = _repo.GetConfig();
        }
        public DateTime GetNextPayday ()
        {
            return DateTime.Now.AddDays( DaysUntilNextPayday() );
        }

        public int DaysUntilNextPayday ()
        {
            var dayCount = 0;
            var today = DateTime.Now;
            Func<DateTime, int> getDayCount = null;

            getDayCount = date =>
            {
                if ( IsPayDay( date ) ) return dayCount;

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
