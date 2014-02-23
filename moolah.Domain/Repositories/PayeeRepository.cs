using System.Collections.Generic;
using moolah.Domain.Interfaces;
using moolah.Domain.Models;

namespace moolah.Domain.Repositories
{
    public class PayeeRepository : IRepository<Payee>
    {
       // private readonly BillWatchContext _db = new BillWatchContext();
        public IEnumerable<Payee> Get ()
        {
            return new List<Payee>();
        }

        public Payee GetById ( int id )
        {
            return new Payee();
        }

        public Payee Create ( Payee payee )
        {
            return new Payee();
        }

        public void Update ( Payee payee )
        {
            
        }

        public void Delete ( int id )
        {
            
        }
    }
}
