using System.Net.Http;
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
            var res = await _client.GetAsync(url);
            return new T
            {
                Success = res.IsSuccessStatusCode,
                StatusCode = res.StatusCode,
                Content = res.Content
            };
                
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
