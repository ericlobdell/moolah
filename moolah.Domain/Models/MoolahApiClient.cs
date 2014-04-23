using moolah.Domain.Services;

namespace moolah.Domain.Models
{
    public class MoolahApiClient
    {
        public BillsApiService Bills { get; set; }
        public PayeesApiService Payees { get; set; }
        public PaymentsApiService Payments { get; set; }
        public SettingsApiService Settings { get; set; }

        public MoolahApiClient()
        {
            Bills = new BillsApiService();
            Payees = new PayeesApiService();
            Payments = new PaymentsApiService();
            Settings = new SettingsApiService();
        }
    }
}
