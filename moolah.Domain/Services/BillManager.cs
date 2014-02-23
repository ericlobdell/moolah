using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using moolah.Domain.Models;
using moolah.Domain.Repositories;

namespace moolah.Domain.Services
{
    public class BillManager
    {
        private readonly BillsRepository _repo = new BillsRepository();
        private readonly PaydayManager _pdMgr = new PaydayManager();

        public List<Bill> GetBillsDueBeforeNextPaycheck ()
        {
            var today = DateTime.Now;
            var nextPayDay = _pdMgr.GetNextPayday();

            return _repo.GetBillsForDateRange( today, nextPayDay );
        }

        public List<Bill> GetBillsForNextPayPeriod ()
        {
            var startingPayday = _pdMgr.GetNextPayday();
            var followingPayDay = _pdMgr.GetPaydayAfterNext();

            return _repo.GetBillsForDateRange( startingPayday, followingPayDay );
        }

        public List<Bill> GetBillsForPayPeriodAfterNext ()
        {
            var startingPayday = _pdMgr.GetPaydayAfterNext();
            var followingPayDay = startingPayday.AddDays( 14 );

            return _repo.GetBillsForDateRange( startingPayday, followingPayDay );
        }

    }
}
