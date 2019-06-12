using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pontoDigital.Models;
using pontoDigital.Repository;

namespace pontoDigital.Controllers
{
    public class DashboardController : Controller
    {
        private ComentarioRepository comentarioRepository = new ComentarioRepository();

        [HttpGet]
        public IActionResult AdicionarComentario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarComentario(IFormCollection frmAddComentario)
        {
            Usuario usuario = new Usuario();
            usuario.Nome = frmAddComentario["nome"];
            
            Comentario comentario = new Comentario(
                textoComentario: frmAddComentario["comentario"]
            );
            comentario.Usuario = usuario;

            comentarioRepository.AdicionarComentario(comentario);
            return View();
        }
    }
}