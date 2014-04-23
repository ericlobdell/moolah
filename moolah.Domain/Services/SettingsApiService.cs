using moolah.Domain.Models;

namespace moolah.Domain.Services
{
    public class SettingsApiService : BaseApiService<Settings>
    {
        private const string Endpoint = "Settings";
        public SettingsApiService()
            : base(Endpoint) { }
    }
}
