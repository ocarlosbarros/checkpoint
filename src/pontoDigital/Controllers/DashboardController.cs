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
            Comentario comentario = new Comentario();
            Usuario usuario = new Usuario();
            usuario.Nome = frmAddComentario["nome"];
            comentario.Usuario = usuario;
            comentario.textoComentario = frmAddComentario["comentario"];

            comentarioRepository.AdicionarComentario(usuario);
            return View();
        }
    }
}