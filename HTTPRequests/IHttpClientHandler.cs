using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HTTPRequests
{
    public interface IHttpClientHandler
    {
        HttpResponseMessage Get(string url);
        HttpResponseMessage Post(string url, HttpContent content);
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostAsync(string url, HttpContent content);
    }
}
