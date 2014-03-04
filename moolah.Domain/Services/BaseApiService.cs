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
        private string _baseUrl;
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
            var res = await _api.Get( BaseUrl + id )
                .ContinueWith( ( r ) => r.Result );
            return JsonConvert.DeserializeObject<T>( res.Content.ReadAsStringAsync().Result );
        }

        public async Task<int> Create(T entity)
        {
            var res = await _api.Post( BaseUrl, entity )
                .ContinueWith( ( r ) => r.Result );
            var test = res.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<int>( test);
        }

        public async Task<bool> Update(T entity)
        {
            return await _api.Put( BaseUrl, entity )
                .ContinueWith( ( r ) => r.Result );
        }

        public async Task<bool> Delete(int id)
        {
            return await _api.Delete( BaseUrl + id )
                .ContinueWith( ( r ) => r.Result );
        }

        public void SetHandler(HttpMessageHandler handler)
        {
            _handler = handler;
        }

        public void SetApiManager(IApiRequestManager<ApiResponse> mgr)
        {
            _api = mgr;
        }

        public void SetBaseUrl(string url)
        {
            _baseUrl = url;
        }

        public BaseApiService(string endpoint)
        {
            if (String.IsNullOrEmpty(_baseUrl))
                _baseUrl = "http://lobdellio.azurewebsites.net/api/";

            if ( _api == null )
                _api = new ApiRequestManager<ApiResponse>();

            BaseUrl = _baseUrl + endpoint + "/";
            Handler = _handler ?? new HttpClientHandler();
        }

        public BaseApiService() { }
    }
}
