using moolah.Domain.Models;

namespace moolah.Domain.Services
{
    public class PayeesApiService : BaseApiService<Payee>
    {
        private const string Endpoint = "Payees";
        public PayeesApiService()
            : base(Endpoint) { }
    }
}
