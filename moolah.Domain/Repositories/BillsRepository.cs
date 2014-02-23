using System;
using System.Collections.Generic;
using moolah.Domain.Interfaces;
using moolah.Domain.Models;

namespace moolah.Domain.Repositories
{
    public class BillsRepository : IRepository<Bill>
    {
       // private readonly BillWatchContext _db = new BillWatchContext();
        public Bill Create ( Bill bill )
        {
            return new Bill();
        }

        public IEnumerable<Bill> Get ()
        {
            return new List<Bill>();
        }

        public Bill GetById ( int id )
        {
           return new Bill();
        }

        public void Delete ( int id )
        {
            
        }

        public void Update ( Bill bill )
        {
            
        }

        public List<Bill> GetBillsForDateRange ( DateTime startDate, DateTime endDate )
        {
            var daysInPeriod = new List<int>();
            var dateUnderTest = startDate;

            while ( dateUnderTest < endDate )
            {
                daysInPeriod.Add( dateUnderTest.Day );
                dateUnderTest = dateUnderTest.AddDays( 1 );
            }
            //return _db.Bills.Where( b =>
            //           daysInPeriod.Contains( b.DueDayOfMonth )
            //       )
            //       .OrderBy( b => b.DueDayOfMonth )
            //       .ToList();

            return new List<Bill>();
        }
    }
}