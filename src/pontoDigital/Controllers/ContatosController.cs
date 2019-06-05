using Microsoft.AspNetCore.Mvc;

namespace pontoDigital.Controllers
{
    public class ContatosController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
    }
}