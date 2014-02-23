using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using moolah.Domain.Interfaces;
using moolah.Domain.Models;

namespace moolah.Domain.Repositories
{
    public class PayeeRepository : BaseRepository<Payee>, IRepository<Payee>
    {
        public PayeeRepository(IMobileServiceClient mobileServiceClient) 
            : base(mobileServiceClient)
        {
        }

    }
}
