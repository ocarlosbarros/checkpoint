using Microsoft.AspNetCore.Mvc;

namespace pontoDigital.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}