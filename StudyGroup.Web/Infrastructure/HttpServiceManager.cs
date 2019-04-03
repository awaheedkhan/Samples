using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Routing;

namespace StudyGroup.Web.Infrastructure
{
    public abstract class HttpServiceManager<T>
    {
        private readonly string _apiUrl;
        private readonly string _jsonSerializedData;

        public HttpServiceManager(string apiUrl, string jsonSerializedData)
        {
            _apiUrl = apiUrl;
            _jsonSerializedData = jsonSerializedData;
        }


        public virtual async Task<T> Post()
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.PostAsJsonAsync<string>(_apiUrl, _jsonSerializedData)
                    .Result.Content
                    .ReadAsAsync<T>();
            }
        }
    }
}