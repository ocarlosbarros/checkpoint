using Microsoft.AspNetCore.Mvc;

namespace pontoDigital.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}