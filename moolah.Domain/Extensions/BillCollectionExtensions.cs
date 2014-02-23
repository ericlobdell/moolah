using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using moolah.Domain.Models;

namespace moolah.Domain.Extensions
{
    public static class BillCollectionExtensions
    {
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
    }
}
