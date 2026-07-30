using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
