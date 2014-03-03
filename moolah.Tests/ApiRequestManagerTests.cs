using System.Net.Http;
using System.Threading.Tasks;
using moolah.Domain.Services;
using Xunit;

namespace moolah.Tests
{
    public class ApiRequestManagerTests
    {
        private HttpClientHandler _handler;
        [Fact]
        public void RequestManagerShouldExist()
        {
            _handler = new HttpClientHandler();
            var mgr = new ApiRequestManager<ApiResponse>();
            Assert.NotNull(mgr);
        }

        [Fact]
        public void ShouldHaveAGetMethod()
        {
            _handler = new HttpClientHandler();
            var mgr = new ApiRequestManager<ApiResponse>();
            var res = mgr.Get("url");
            Assert.NotNull(res);
        }

        [Fact]
        public void GetShouldReturnTaskOfIApiResponse()
        {
            _handler = new HttpClientHandler();
            var mgr = new ApiRequestManager<ApiResponse>();
            var res = mgr.Get("url");
            Assert.IsType<Task<ApiResponse>>(res);
        }

        [Fact]
        public void ShouldHaveAPutMethod ()
        {
            _handler = new HttpClientHandler();
            var mgr = new ApiRequestManager<ApiResponse>();
            var res = mgr.Put( "url", new object());
            Assert.NotNull( res );
        }

        [Fact]
        public async void PutShouldReturnTaskOfIApiResponse ()
        {
            _handler = new HttpClientHandler();
            var mgr = new ApiRequestManager<ApiResponse>();
            await mgr.Put( "url", new object());
            
        }

        [Fact]
        public async void PupShouldRequireObject ()
        {
            _handler = new HttpClientHandler();
            var mgr = new ApiRequestManager<ApiResponse>();
            await mgr.Put( "url", new object());
        }

        [Fact]
        public async void ShouldHaveAPostMethod ()
        {
            _handler = new HttpClientHandler();
            var mgr = new ApiRequestManager<ApiResponse>();
            await mgr.Post( "url", new object());
        }

        [Fact]
        public async void PostShouldReturnTaskOfIApiResponse ()
        {
            _handler = new HttpClientHandler();
            var mgr = new ApiRequestManager<ApiResponse>();
            await mgr.Post( "url", new object());
        }

        [Fact]
        public async void PostShouldRequireObject ()
        {
            _handler = new HttpClientHandler();
            var mgr = new ApiRequestManager<ApiResponse>();
            await mgr.Post( "url", new object { } );
        }

        [Fact]
        public async void ShouldHaveADeleteMethod ()
        {
            _handler = new HttpClientHandler();
            var mgr = new ApiRequestManager<ApiResponse>();
            await mgr.Delete( "url" );
        }

        [Fact]
        public async void DeleteShouldReturnTaskOfIApiResponse ()
        {
            _handler = new HttpClientHandler();
            var mgr = new ApiRequestManager<ApiResponse>();
            await mgr.Delete( "url" );
        }
    }
}
