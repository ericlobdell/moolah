using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using moolah.Domain.Interfaces;
using moolah.Domain.Models;

namespace moolah.Domain.Services
{
    public class BillsApiService : BaseApiService<Bill>
    {
        private const string Endpoint = "Bills";
        public BillsApiService()
            : base(Endpoint) { }
    }
}
