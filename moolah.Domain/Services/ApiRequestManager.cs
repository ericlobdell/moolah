using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using moolah.Domain.Interfaces;
using Newtonsoft.Json;

namespace moolah.Domain.Services
{
    public class ApiRequestManager<T> : IApiRequestManager<T> 
        where T : IApiResponse, new()
    {
        private HttpClient _client;
        private HttpMessageHandler _handler;
        public ApiRequestManager()
        {
            _handler = new HttpClientHandler();
            _client = new HttpClient(_handler);
        }
        public async Task<T> Get(string url)
        {
            var response = new T();
            return await _client.GetAsync(url)
                .ContinueWith((task) =>
                {
                    var res = task.Result;
                    response.Success = res.IsSuccessStatusCode;
                    response.StatusCode = res.StatusCode;
                    response.Content = res.Content;

                    return response;
                });
            
        }

        public async Task<bool> Put ( string url, object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent( json, Encoding.UTF8, "application/json" );
            var res = await _client.PutAsync( url, content );
            return res.IsSuccessStatusCode;
        }

        public async Task<T> Post ( string url, object obj )
        {
            var json = JsonConvert.SerializeObject( obj );
            var content = new StringContent( json, Encoding.UTF8, "application/json" );
            var res = await _client.PostAsync( url, content );
            return new T
            {
                Success = res.IsSuccessStatusCode,
                StatusCode = res.StatusCode,
                Content = res.Content
            };
        }

        public async Task<bool> Delete ( string url)
        {
            var res = await _client.DeleteAsync( url );
            return res.IsSuccessStatusCode;
        }

    }
}
