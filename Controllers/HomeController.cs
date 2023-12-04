using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebDemo14112023.Models;

namespace WebDemo14112023.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Login() {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if(model.UserName.Contains("admin") && model.Password.Contains("admin"))
            {
                TempData["Info"] = "Admin";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult List()
        {
            var list = ProductDao.Instance.GetAllProducts().OrderByDescending(p=>p.Price);
            return View(list);
        }

        public IActionResult Index()
        {
            return View();
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