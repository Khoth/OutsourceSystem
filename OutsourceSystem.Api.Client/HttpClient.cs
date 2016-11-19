using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace OutsourceSystem.Api.Client
{
    internal static class HttpClient
    {
        private const string ContentType = "application/json";

        public static Task<string> GetAsync(string url)
        {
            return RequestAsync(url, "GET", ContentType);
        }

        public static Task<string> PostAsync(string url)
        {
            return RequestAsync(url, "POST", ContentType);
        }

        private static async Task<string> RequestAsync(string url, string method, string contentType)
        {
            var request = WebRequest.CreateHttp(url);
            request.Method = method;
            request.ContentType = contentType;

            using (var response = await request.GetResponseAsync())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    using (var streamReader = new StreamReader(responseStream))
                    {
                        return await streamReader.ReadToEndAsync();
                    }
                }
            }
        }
    }
}