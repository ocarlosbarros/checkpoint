using Microsoft.AspNetCore.Mvc;

namespace CheckPoint.Controllers
{
    public class FaqController : Controller
    {
        private const string SESSION_EMAIL = "_EMAIL";
        private const string SESSION_USUARIO = "_USUARIO";
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}