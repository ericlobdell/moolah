using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using moolah.Domain.Interfaces;
using moolah.Domain.Models;

namespace moolah.Domain.Repositories
{
    public class BillsRepository : BaseRepository<Bill>, IRepository<Bill>
    {
        public BillsRepository(IMobileServiceClient mobileServiceClient) 
            : base(mobileServiceClient) {}

        public async Task<List<Bill>>GetBillsForDateRange ( DateTime startDate, DateTime endDate )
        {
             return await base.GetTable()
                 .Where(b => b.DueDate.Date >= startDate && b.DueDate < endDate )
                 .ToListAsync();
        }
    }
}