using Microsoft.AspNetCore.Mvc;

namespace pontoDigital.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpPost]
        public IActionResult CadastrarUsuario()
        {
            
            return View();
        }
        
    }
}