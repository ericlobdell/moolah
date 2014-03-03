using System.Net;
using System.Net.Http;

namespace moolah.Domain.Interfaces
{
    public interface IApiResponse
    {
        bool Success { get; set; }
        HttpContent Content { get; set; }
        HttpStatusCode StatusCode { get; set; }
    }
}
