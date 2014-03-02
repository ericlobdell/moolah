using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using moolah.Domain.Models;

namespace moolah.Domain.Services
{
    public class BillManager
    {
        //private readonly BillsRepository _repo;
        //private readonly PaydayManager _pdMgr = new PaydayManager();

        //public async Task <List<Bill>> GetBillsDueBeforeNextPaycheck ()
        //{
        //    var today = DateTime.Now;
        //    var nextPayDay = _pdMgr.GetNextPayday();

        //    return await _repo.GetBillsForDateRange( today, nextPayDay );
        //}

        //public async Task<List<Bill>> GetBillsForNextPayPeriod ()
        //{
        //    var startingPayday = _pdMgr.GetNextPayday();
        //    var followingPayDay = _pdMgr.GetPaydayAfterNext();

        //    return await _repo.GetBillsForDateRange( startingPayday, followingPayDay );
        //}

        //public async Task<List<Bill>> GetBillsForPayPeriodAfterNext ()
        //{
        //    var startingPayday = _pdMgr.GetPaydayAfterNext();
        //    var followingPayDay = startingPayday.AddDays( 14 );

        //    return await _repo.GetBillsForDateRange( startingPayday, followingPayDay );
        //}

    }
}
