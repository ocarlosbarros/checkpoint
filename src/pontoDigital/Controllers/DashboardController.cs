using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace pontoDigital.Controllers
{
    public class DashboardController : Controller
    {
        [HttpGet]
        public IActionResult AdicionarComentario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarComentario(IFormCollection frmAddComentario)
        {
            return View();
        }
    }
}