using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace pontoDigital.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

       [HttpPost]
        public IActionResult CadastrarUsuario(IFormCollection frmCadastrarUsuario)
        {
            ViewBag.titulo = "Cadastro";
            return View();
        }
        
    }
}