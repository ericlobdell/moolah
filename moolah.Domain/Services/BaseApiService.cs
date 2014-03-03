using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using moolah.Domain.Interfaces;
using Newtonsoft.Json;

namespace moolah.Domain.Services
{
    public class BaseApiService<T>
    {
        private string _endpoint;
        private HttpMessageHandler _handler;
        private IApiRequestManager<ApiResponse> _api; 
        public HttpMessageHandler Handler { get; set; }
        public string BaseUrl { get; set; }
        public async Task<IEnumerable<T>> Get()
        {
            var res = await _api.Get(BaseUrl).ContinueWith((r) => r.Result);

            return JsonConvert.DeserializeObject<IEnumerable<T>>( res.Content.ReadAsStringAsync().Result );
        }

        public async Task<T> GetById(int id)
        {
            var res = await _api.Get( BaseUrl + id ).ContinueWith( ( r ) => r.Result );
            return JsonConvert.DeserializeObject<T>( res.Content.ReadAsStringAsync().Result );
        }

        public async Task<int> Create(T entity)
        {
            var res = await _api.Post( BaseUrl, entity ).ContinueWith( ( r ) => r.Result );
            return JsonConvert.DeserializeObject<int>( res.Content.ReadAsStringAsync().Result );
        }

        public async Task<bool> Update(T entity)
        {
            return await _api.Put( BaseUrl, entity ).ContinueWith( ( r ) => r.Result );
        }

        public async Task<bool> Delete(int id)
        {
            return await _api.Delete( BaseUrl + id ).ContinueWith( ( r ) => r.Result );
        }

        public void SetHandler(HttpMessageHandler handler)
        {
            _handler = handler;
        }

        public void SetApiManager(IApiRequestManager<ApiResponse> mgr)
        {
            _api = mgr;
        }

        public BaseApiService(string endpoint)
        {
            BaseUrl = "http://lobdellio.azurewebsites.net/api/" + endpoint + "/";
            Handler = _handler ?? new HttpClientHandler();

            if (_api == null)
                _api = new ApiRequestManager<ApiResponse>();
        }

        public BaseApiService() { }
    }
}
