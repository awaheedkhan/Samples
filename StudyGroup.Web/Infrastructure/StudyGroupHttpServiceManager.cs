using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace StudyGroup.Web.Infrastructure
{
    public class StudyGroupHttpServiceManager 
    {
        private readonly string _apiUrl;
        private readonly string _jsonSerializedData;

        public StudyGroupHttpServiceManager(string apiUrl, string[,] data)
        {
            _apiUrl = apiUrl;
            _jsonSerializedData = JsonConvert.SerializeObject(data);
        }

        public virtual async Task<string[][]> PostAsync()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromMinutes(30);

                return await httpClient.PostAsJsonAsync<string>(_apiUrl, _jsonSerializedData)
                    .Result.Content
                    .ReadAsAsync<string[][]>();
            }
        }
    }
}