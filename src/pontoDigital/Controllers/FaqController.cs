using Microsoft.AspNetCore.Mvc;

namespace pontoDigital.Controllers
{
    public class FaqController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}