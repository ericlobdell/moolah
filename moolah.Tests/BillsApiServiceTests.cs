using moolah.Domain.Services;
using Xunit;

namespace moolah.Tests
{
    public class BillsApiServiceTests
    {
        [Fact]
        public void InstantiatesWithCorrectEndpoint()
        {
            var svc = new BillsApiService();
            const string expected = "http://ericlobdell.azurewebsites.net/api/Bills/";
            Assert.Equal(expected, svc.BaseUrl);
        }


    }
}
