using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using moolah.Domain.Interfaces;
using moolah.Domain.Models;

namespace moolah.Domain.Repositories
{
    public class PaymentRepository : IRepository<Payment>
    {
       // private readonly BillWatchContext _db = new BillWatchContext();

        public IEnumerable<Payment> Get ()
        {
            return new List<Payment>();
        }
        public Payment GetById ( int id )
        {
            return new Payment();
        }

        public void Update ( Payment payment )
        {
            
        }

        public Payment Create ( Payment payment )
        {
           return new Payment();
        }

        public void Delete ( int id )
        {
            
        }
    }
}
