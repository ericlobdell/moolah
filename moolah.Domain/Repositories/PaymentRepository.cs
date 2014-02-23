using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using moolah.Domain.Interfaces;
using moolah.Domain.Models;

namespace moolah.Domain.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IRepository<Payment>
    {
        public PaymentRepository(IMobileServiceClient mobileServiceClient) : base(mobileServiceClient)
        {
        }

    }
}
