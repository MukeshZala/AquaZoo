using AquaZooWeb.UIRepository;
using Microsoft.AspNetCore.Mvc;

namespace AquaZooWeb.Controllers
{
    public class AquaZooController : Controller
    {
        private readonly IAquaZooRepository _repo;

        public AquaZooController( IAquaZooRepository aquaZooRepository)
        {
            _repo = aquaZooRepository; 
        }
        public IActionResult Index2()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {

            return Json( new {  data = await _repo.GetAllAsync (WebUtility.APIAquaZooPath ) });

        }
    }
}
