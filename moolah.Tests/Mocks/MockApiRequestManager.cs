using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using moolah.Domain.Interfaces;
using moolah.Domain.Models;
using moolah.Domain.Services;
using Newtonsoft.Json;

namespace moolah.Tests.Mocks
{
    public class MockApiRequestManager : IApiRequestManager<ApiResponse>
    {
        private readonly bool _isBeingUsed;
        public bool GetWasCalled { get; set; }
        public bool PutWasCalled { get; set; }
        public bool PostWasCalled { get; set; }
        public bool DeleteWasCalled { get; set; }

        private bool _preferredBoolResponse;

        public MockApiRequestManager()
        {
            _isBeingUsed = true;
            _preferredBoolResponse = true;
            GetWasCalled = false;
            PutWasCalled = false;
            PostWasCalled = false;
            DeleteWasCalled = false;
        }
        public Task<ApiResponse> Get(string url)
        {
            GetWasCalled = true;
            var list = JsonConvert.SerializeObject(new List<object>());
            var content = new StringContent(list);
            return new Task<ApiResponse>(() => 
                new ApiResponse
                {
                    Success = true,
                    StatusCode = HttpStatusCode.Accepted,
                    Content = content
                });
        }

        public Task<bool> Put(string url, object obj)
        {
            PutWasCalled = true;
            return new Task<bool>( () => _preferredBoolResponse );
        }

        public Task<ApiResponse> Post(string url, object obj)
        {
            PostWasCalled = true;
            return new Task<ApiResponse>( () => new ApiResponse() );
        }

        public Task<bool> Delete(string url)
        {
            DeleteWasCalled = true;
            return new Task<bool>( () => _preferredBoolResponse );
        }

        public bool Verify()
        {
            return _isBeingUsed;
        }

        public void SetBoolResponseToFalse()
        {
            _preferredBoolResponse = false;
        }



    }
}
