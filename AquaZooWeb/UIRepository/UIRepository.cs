using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace AquaZooWeb.UIRepository
{
    public class UIRepository<T> : IUIRepository<T> where T : class
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private const string mediaType = "application/json";

        public UIRepository(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory; 
        }

        public async Task<bool> CreateAsync(string url, T createObj)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if ( createObj != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(createObj), Encoding.UTF8, mediaType);

            }
            else
            {
                return false; 
            }

            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage httpResponse = await client.SendAsync(request);
            if ( httpResponse.StatusCode== System.Net.HttpStatusCode.Created)
            {
                return true;
            }
            else
            {
                return false; 
            }

        }

        public async Task<bool> DeleteAsync(string url, int Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url+Id);

            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage httpResponse = await client.SendAsync(request);

            if ( httpResponse.StatusCode == HttpStatusCode.NoContent)
            {
                return true; 
            }
            else
            {
                return false; 
            }

        }

        public async Task<IEnumerable<T>> GetAllAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = _httpClientFactory.CreateClient();

            HttpResponseMessage responseMessage = await client.SendAsync(request);

             if ( responseMessage.StatusCode == HttpStatusCode.OK)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString); 

            }

            return null;

        }

        public async Task<T> GetAsync(string url, int Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + Id);
            var client = _httpClientFactory.CreateClient();

            HttpResponseMessage responseMessage = await client.SendAsync(request);
            if (responseMessage !=null )
            {
                string jsonString = await responseMessage.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(jsonString); 

            }

            return null; 
        }

        public async Task<bool> UpdateAsync(string url, T createObj)
        {
            var request = new HttpRequestMessage(HttpMethod.Patch, url);
            var client = _httpClientFactory.CreateClient();

            if ( createObj != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(createObj), Encoding.UTF8, mediaType);

            }
            else
            {
               return  false; 
            }

            HttpResponseMessage responseMessage = await client.SendAsync(request); 
            if ( responseMessage != null && responseMessage.StatusCode == HttpStatusCode.OK)
            {
                return true; 
            }
            return false; 


        }
    }
}
