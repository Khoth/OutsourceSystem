using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace OutsourceSystem.Api.Client.Services
{
    public abstract class ServiceBase
    {
        protected readonly string BaseUrl;
        protected NameValueCollection Headers { get; }

        private ServiceBase()
        {
            Headers = new NameValueCollection();
            Headers.Add("Content-Type", "application/json");
        }

        protected ServiceBase(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        protected async Task<T> GetAsync<T>(string url, object parameters = null)
        {
            var responseString = await HttpClient.GetAsync($"{BaseUrl}/{url}", Headers, parameters);
            return JsonConvert.DeserializeObject<T>(responseString);
        }

        protected async Task<T> PostAsync<T>(string url, object parameters = null, object content = null)
        {
            var responseString = await HttpClient.PostAsync($"{BaseUrl}/{url}", Headers, parameters, content);
            return JsonConvert.DeserializeObject<T>(responseString);
        }
    }
}