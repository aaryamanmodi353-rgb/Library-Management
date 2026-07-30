using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<LoginModel> PutValue()
        {
            var users = new List<LoginModel>
            {
                new LoginModel{id=1,username="admin",password="12345"},
                new LoginModel{id=2,username="mycodingproject",password="myc546"},
                new LoginModel{id=3,username="my",password="myc"}
            };
            return users;
        }

        [HttpPost]
        public IActionResult Verify(LoginModel usr)
        {
            if (string.IsNullOrEmpty(usr.username) || string.IsNullOrEmpty(usr.password))
            {
                ViewBag.message = "Login Failed: Missing username or password.";
                return View("Index");
            }

            var users = PutValue();
            var matchedUser = users.FirstOrDefault(u => 
                string.Equals(u.username, usr.username, StringComparison.OrdinalIgnoreCase) && 
                u.password == usr.password);

            if (matchedUser != null)
            {
                TempData["message"] = "Login Success";
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ViewBag.message = "Login Failed: Invalid username or password.";
                return View("Index");
            }
        }
    }
}
