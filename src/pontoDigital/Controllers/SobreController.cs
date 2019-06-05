using Microsoft.AspNetCore.Mvc;

namespace pontoDigital.Controllers
{
    public class SobreController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}