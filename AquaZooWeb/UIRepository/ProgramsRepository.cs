using AquaZooWeb.Models;

namespace AquaZooWeb.UIRepository
{
    public class ProgramsRepository: UIRepository<LocationProgramEntity>, IProgramsRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProgramsRepository(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _clientFactory = httpClientFactory;
        }


    }
}
