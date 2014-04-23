using moolah.Domain.Models;

namespace moolah.Domain.Services
{
    public class PaymentsApiService : BaseApiService<Payment>
    {
        private const string Endpoint = "Payments";
        public PaymentsApiService()
            : base(Endpoint) { }
    }
}
