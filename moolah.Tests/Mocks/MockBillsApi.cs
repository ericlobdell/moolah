using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using moolah.Domain.Interfaces;
using moolah.Domain.Services;
using moolah.Domain.Models;

namespace moolah.Tests.Mocks
{
    public class MockBillsApiervice : IApiService<Bill>
    {
        private List<Bill> _bills = new List<Bill>
        {
            new Bill
            {
                Name = "Fake Bill 1",
                Amount = 125.00m,
                DueDate = new DateTime(2014, 03, 14),
                PayeeId = 1,
                IsAutoPay = true,
                IsPaid = false,
                IsChargedInterest = true,
                InterestRate = 12.0m
            },
            new Bill
            {
                Name = "Fake Bill 2",
                Amount = 25.00m,
                DueDate = new DateTime(2014, 03, 10),
                PayeeId = 1,
                IsAutoPay = false,
                IsPaid = true,
                IsChargedInterest = true,
                InterestRate = 12.0m
            },
            new Bill
            {
                Name = "Fake Bill 1",
                Amount = 100.00m,
                DueDate = new DateTime(2014, 03, 14),
                PayeeId = 1,
                IsAutoPay = true,
                IsPaid = false,
                IsChargedInterest = true,
                InterestRate = 12.0m
            }
        }; 
        public Task<IEnumerable<Bill>> Get()
        {
            return new Task<IEnumerable<Bill>>(() => _bills);
        }

        public IEnumerable<Bill> GetSync()
        {
            return _bills;
        }

        public Task<Bill> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Bill GetByIdSync (int id)
        {
            return _bills.FirstOrDefault(b => b.Id == id);
        }

        public Task<int> Create(Bill entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Bill entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void SetApiManager(IApiRequestManager<ApiResponse> mgr)
        {
            throw new NotImplementedException();
        }

        public void SetBaseUrl(string url)
        {
            throw new NotImplementedException();
        }

        public void SetHandler(HttpMessageHandler handler)
        {
            throw new NotImplementedException();
        }
    }
}
