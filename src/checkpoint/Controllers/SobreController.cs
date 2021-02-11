using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace pontoDigital.Controllers
{
    public class SobreController : Controller
    {
        private const string SESSION_EMAIL = "_EMAIL";
        private const string SESSION_USUARIO = "_USUARIO";
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["User"] = HttpContext.Session.GetString(SESSION_USUARIO);
            return View();
        }
    }
}