using AquaZooWeb.Models;
using AquaZooWeb.UIRepository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AquaZooWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountRepository _accountRepository;

        public HomeController(ILogger<HomeController> logger, IAccountRepository accountRepository)
        {
            _logger = logger;
            _accountRepository = accountRepository; 
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            User obj = new User();
            return View(obj );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User Obj )
        {
            User obj = await _accountRepository.LoginAsync(WebUtility.APIAccountPath + "/Authenticate", Obj); 

            if ( obj.Token == null)
            {
                return View(); 
            }

            HttpContext.Session.SetString( WebUtility.TokenName , obj.Token);
            return RedirectToAction("Index"); 

            
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User Obj)
        {
            bool result = await _accountRepository.RegisterAsync(WebUtility.APIAccountPath + "/Register", Obj);

            if ( result  == false )
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(User Obj)
        {
            HttpContext.Session.SetString( WebUtility.TokenName ,"");

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}