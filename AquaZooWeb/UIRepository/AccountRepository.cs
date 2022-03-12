using AquaZooWeb.Models;
using Newtonsoft.Json;
using System.Text;

namespace AquaZooWeb.UIRepository
{
    public class AccountRepository : UIRepository<User>, IAccountRepository
    {
        IHttpClientFactory _clientfactory;

        public AccountRepository(IHttpClientFactory httpClient):base(httpClient)
        {
            _clientfactory = httpClient; 
        }

        public async Task<User> LoginAsync(string url, User newUser)
        {


            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (newUser != null)
            {
                request.Content = new StringContent(
                        JsonConvert.SerializeObject(newUser),
                         Encoding.UTF8,
                         "application/json"
                    );
            }
            else
            {
                return new User(); 
            }

            var client = _clientfactory.CreateClient();
            HttpResponseMessage httpResponseMessage = await client.SendAsync(request);

            if (httpResponseMessage != null && httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(jsonString);
            }
            else
            {
                return new User(); ;
            }


        }

        public async Task<bool> RegisterAsync(string url, User validateUser)
        {
            
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (validateUser != null)
            {
                request.Content = new StringContent(
                        JsonConvert.SerializeObject(validateUser),
                         Encoding.UTF8,
                         "application/json"
                    );
            }
            else
            {
                return false ;
            }

            var client = _clientfactory.CreateClient();
            HttpResponseMessage httpResponseMessage =await  client.SendAsync(request);

            if ( httpResponseMessage != null && httpResponseMessage.StatusCode== System.Net.HttpStatusCode.OK)
            {
                var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
                return true; 
            }
            else
            {
                return false ;
            }


        }
    }
}
