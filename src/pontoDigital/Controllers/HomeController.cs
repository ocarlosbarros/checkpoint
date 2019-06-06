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

        [HttpGet]
        public IActionResult CadastrarUsuario()
        {
            ViewBag.titulo = "Cadastro";
            return View();
        }
    }
}