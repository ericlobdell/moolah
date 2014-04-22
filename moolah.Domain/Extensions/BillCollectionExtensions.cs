using System.Collections.Generic;
using System.Linq;
using moolah.Domain.Models;
using moolah.Domain.Services;

namespace moolah.Domain.Extensions
{
    public static class BillCollectionExtensions
    {
        private static PaydayManager _paydayManager;
        public static decimal TotalDue ( this IEnumerable<Bill> bills )
        {
            return bills.Select( b => b.Amount ).Sum();
        }

        public static IEnumerable<Bill> AreNotPaid ( this IEnumerable<Bill> bills )
        {
            return bills.Where( b => b.IsPaid == false );
        }

        public static IEnumerable<Bill> ArePaid ( this IEnumerable<Bill> bills )
        {
            return bills.Where( b => b.IsPaid );
        }

        public static IEnumerable<Bill> AreAutoPay ( this IEnumerable<Bill> bills )
        {
            return bills.Where( b => b.IsAutoPay );
        }

        public static IEnumerable<Bill> AreNotAutoPay ( this IEnumerable<Bill> bills )
        {
            return bills.Where( b => b.IsAutoPay == false );
        }

        public static IEnumerable<Bill> DueBeforeNextPaycheck ( this IEnumerable<Bill> bills, Settings settings )
        {
            _paydayManager = new PaydayManager( settings );
            var today = DateTimeProvider.GetCurrentDateTime();
            var nextPayDay = _paydayManager.GetNextPayday();
            return bills.Where( b => b.DueDate >= today && b.DueDate < nextPayDay );
        }

        public static IEnumerable<Bill> DueNextPayPeriod ( this IEnumerable<Bill> bills, Settings settings )
        {
            _paydayManager = new PaydayManager( settings );
            var nextPayDay = _paydayManager.GetNextPayday();
            var payDayAfterNext = _paydayManager.GetPaydayAfterNext();
            return bills.Where( b => b.DueDate >= nextPayDay && b.DueDate < payDayAfterNext );
        }
    }
}
