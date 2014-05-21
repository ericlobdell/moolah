using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using moolah.Domain.Interfaces;
using moolah.Domain.Models;
using Newtonsoft.Json;

namespace moolah.Domain.Services
{
    public class BaseApiService<T> : IApiService<T>
    {
        private string _endpoint;
        private string _baseUrl;
        public IApiRequestManager<ApiResponse> Api { get; set; }
        public string BaseUrl { get; set; }

        public BaseApiService ( string endpoint )
        {
            if ( String.IsNullOrEmpty( _baseUrl ) )
				_baseUrl = "http://**********/api/";

            if ( Api == null )
                Api = new ApiRequestManager<ApiResponse>();

            BaseUrl = _baseUrl + endpoint + "/";
        }

        public BaseApiService () { }
        public async Task<IEnumerable<T>> Get()
        {
            var res = await Api.Get(BaseUrl).ContinueWith((r) => r.Result);

            return JsonConvert.DeserializeObject<IEnumerable<T>>( res.Content.ReadAsStringAsync().Result );
        }

        public async Task<T> GetById(int id)
        {
            var res = await Api.Get( BaseUrl + id )
                .ContinueWith( ( r ) => r.Result );
            return JsonConvert.DeserializeObject<T>( res.Content.ReadAsStringAsync().Result );
        }

        public async Task<int> Create(T entity)
        {
            var res = await Api.Post( BaseUrl, entity )
                .ContinueWith( ( r ) => r.Result );
            return JsonConvert.DeserializeObject<int>( res.Content.ReadAsStringAsync().Result);
        }

        public async Task<bool> Update(T entity)
        {
            return await Api.Put( BaseUrl, entity )
                .ContinueWith( ( r ) => r.Result );
        }

        public async Task<bool> Delete(int id)
        {
            return await Api.Delete( BaseUrl + id )
                .ContinueWith( ( r ) => r.Result );
        }


        public void SetApiManager(IApiRequestManager<ApiResponse> mgr)
        {
            Api = mgr;
        }

        public void SetBaseUrl(string url)
        {
            BaseUrl = url;
        }

        
    }
}
