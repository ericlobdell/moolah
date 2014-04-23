using moolah.Domain.Models;
using moolah.Domain.Services;
using moolah.Tests.Mocks;
using Xunit;

namespace moolah.Tests
{
    public class BaseApiServiceTests
    {
        [Fact]
        public void CanBeINstantiatedWithoutUrl()
        {
            var svc = new BaseApiService<Bill>();
            Assert.NotNull(svc);
        }
        [Fact]
        public void SetBaseUrlSetsBaseUrl()
        {
            var svc = new BaseApiService<Bill>("endpoint");
            var sutBefore = svc.BaseUrl;
            const string expectedBefore = "http://ericlobdell.azurewebsites.net/api/endpoint/";
            Assert.Equal(sutBefore, expectedBefore);

            svc.SetBaseUrl("http://fakeurl.com/api/endpoint");
            var sutAfter = svc.BaseUrl;
            const string expectedAfter = "http://fakeurl.com/api/endpoint";
            Assert.Equal( sutAfter, expectedAfter );
        }

        [Fact]
        public void SetApiServiceSetsApiService()
        {
            var svc = new BaseApiService<Bill>( "endpoint" );
            svc.SetApiManager( new MockApiRequestManager() );

            Assert.IsType<MockApiRequestManager>(svc.Api);
        }

        [Fact]
        public void GetCallsGetOnApiService()
        {
            var svc = new BaseApiService<Bill>( "endpoint" );
            var mgr = new MockApiRequestManager();
            svc.SetApiManager(mgr);

            Assert.False( mgr.GetWasCalled );
            var testGetCall = svc.Get();
            Assert.True(mgr.GetWasCalled);
        }


        [Fact]
        public void GetByIdCallsGetOnApiService ()
        {
            var svc = new BaseApiService<Bill>( "endpoint" );
            var mgr = new MockApiRequestManager();
            svc.SetApiManager( mgr );

            Assert.False( mgr.GetWasCalled );
            var testGetCall = svc.GetById(12);
            Assert.True( mgr.GetWasCalled );
        }

        [Fact]
        public void CreateCallsPostOnApiService ()
        {
            var svc = new BaseApiService<Bill>( "endpoint" );
            var mgr = new MockApiRequestManager();
            svc.SetApiManager( mgr );

            Assert.False( mgr.PostWasCalled );
            var testGetCall = svc.Create( new Bill() );
            Assert.True( mgr.PostWasCalled );
        }

        [Fact]
        public void UpdateCallsPutOnApiService ()
        {
            var svc = new BaseApiService<Bill>( "endpoint" );
            var mgr = new MockApiRequestManager();
            svc.SetApiManager( mgr );

            Assert.False( mgr.PutWasCalled );
            var testGetCall = svc.Update( new Bill() );
            Assert.True( mgr.PutWasCalled );
        }

        [Fact]
        public void DeleteCallsDeleteOnApiService ()
        {
            var svc = new BaseApiService<Bill>( "endpoint" );
            var mgr = new MockApiRequestManager();
            svc.SetApiManager( mgr );

            Assert.False( mgr.DeleteWasCalled ); 
            var testGetCall = svc.Delete( 12 );
            Assert.True( mgr.DeleteWasCalled ); 
        }



    }
}
