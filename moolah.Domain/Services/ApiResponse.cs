using System.Net;
using System.Net.Http;
using moolah.Domain.Interfaces;

namespace moolah.Domain.Services
{
    public class ApiResponse : IApiResponse
    {
        public bool Success { get; set; }
        public HttpContent Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
