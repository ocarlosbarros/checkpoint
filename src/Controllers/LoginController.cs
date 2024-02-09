using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CheckPoint.Enums;
using CheckPoint.Repository;

namespace CheckPoint.Controllers
{
    public class LoginController : Controller
    {
        #region "Import" repositories
        private UsuarioRepository _usuarioRepository = new UsuarioRepository();
        #endregion
        public const string SessionEmail = "_EMAIL";
        public const string SessionUsuario = "_USUARIO";
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(IFormCollection frmLogin)
        {
            var email = frmLogin["email"];
            var senha = frmLogin["senha"];

            var usuario = _usuarioRepository.BuscarPor(email);

            if(usuario != null && usuario.Senha.Equals(senha))
            {
                if ( usuario.Permissao.Equals(EnumPermissao.ADMNISTRADOR))
                    {
                        HttpContext.Session.SetString(SessionEmail, email);
                        HttpContext.Session.SetString(SessionUsuario, usuario.Nome); 
                        
                        return RedirectToAction("Index", "Dashboard");

                    }else
                        {
                            HttpContext.Session.SetString(SessionEmail, email);
                            HttpContext.Session.SetString(SessionUsuario, usuario.Nome); 
                            
                            return RedirectToAction("CadastrarComentario", "Usuario");
                        }
            }   
            return RedirectToAction("CadastrarUsuario", "Usuario");
        }

        public IActionResult Logout() 
        {
            HttpContext.Session.Remove(SessionEmail);
            HttpContext.Session.Remove(SessionUsuario);
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}