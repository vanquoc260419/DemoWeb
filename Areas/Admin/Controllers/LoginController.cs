using Microsoft.AspNetCore.Mvc;
using WebDemo14112023.Models;

namespace WebDemo14112023.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UserName.Contains("admin") && model.Password.Contains("admin"))
                {
                    TempData["Info"] = "Admin";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Fail"] = "Tên đăng nhập hoặc mật khẩu không đúng!";
                }
            }
            else
            {
                ModelState.AddModelError("Error",
                                 "Please input field full!");
            }
            return View(model);
        }
    }
}
