using OutsorceSystem.Common.Helpers.Extensions;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OutsourceSystem.Api.Client
{
    internal static class HttpClient
    {
        public static Task<string> GetAsync(string url, NameValueCollection headers, object parameters = null)
        {
            return RequestAsync(url, "GET", headers, parameters);
        }

        public static Task<string> PostAsync(string url, NameValueCollection headers, object parameters = null, object content = null)
        {
            return RequestAsync(url, "POST", headers, parameters, content);
        }
        
        private static async Task<string> RequestAsync(string url, string method, NameValueCollection headers, object parameters = null, object content = null)
        {
            var fullUrl = parameters != null ? $"{url}?{ObjectToQueryParams(parameters)}" : url;
            var request = WebRequest.CreateHttp(fullUrl);

            request.Headers.Add(headers);

            if (content != null)
            {
                var requestStream = await request.GetRequestStreamAsync();
                var bytes = content.ToByteArray();
                await requestStream.WriteAsync(bytes, 0, bytes.Length);
            }

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

        private static string ObjectToQueryParams(object parameters)
        {
            var keyValueCollection = parameters.GetType().GetProperties()
                .ToDictionary(property => property.Name, property => property.GetValue(parameters))
                .Select(entry => $"{entry.Key}={entry.Value.ToString() ?? string.Empty}");

            return string.Join("&", keyValueCollection);
        }
    }
}