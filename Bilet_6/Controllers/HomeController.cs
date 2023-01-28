using Microsoft.AspNetCore.Mvc;

namespace Bilet_6.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
