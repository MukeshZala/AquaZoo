using AquaZooWeb.Models;

namespace AquaZooWeb.UIRepository
{
    public class AquaZooRepository:UIRepository<AquaZooEntity> , IAquaZooRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public AquaZooRepository( IHttpClientFactory httpClientFactory):base(httpClientFactory)
        {
            _clientFactory = httpClientFactory; 
        }


    }
}
