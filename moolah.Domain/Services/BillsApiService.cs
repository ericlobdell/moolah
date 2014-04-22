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
