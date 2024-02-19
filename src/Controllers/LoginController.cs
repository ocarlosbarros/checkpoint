using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CheckPoint.Enums;
using CheckPoint.Interfaces;
using CheckPoint.Repository;

namespace CheckPoint.Controllers
{
    public class LoginController : Controller
    {
        public const string SessionEmail = "_EMAIL";
        public const string SessionUsuario = "_USUARIO";
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromServices] IUserService userService,IFormCollection frmLogin)
        {
            var email = frmLogin["email"];
            var password = frmLogin["senha"];

            var user = userService.GetUserBy(email, password);
            
            if (user == null)
                return RedirectToAction("RegisterUser", "User");
            
            return View();
        }

        /*[HttpPost]
        public IActionResult Login(IFormCollection frmLogin)
        {
            var email = frmLogin["email"];
            var senha = frmLogin["senha"];

            var usuario = _usuarioRepository.BuscarPor(email);

            if(usuario != null && usuario.Senha.Equals(senha))
            {
                if ( usuario.Permission.Equals(EnumPermission.ADMNISTRADOR))
                    {
                        HttpContext.Session.SetString(SessionEmail, email);
                        HttpContext.Session.SetString(SessionUsuario, usuario.Nome); 
                        
                        return RedirectToAction("Index", "Dashboard");

                    }else
                        {
                            HttpContext.Session.SetString(SessionEmail, email);
                            HttpContext.Session.SetString(SessionUsuario, usuario.Nome); 
                            
                            return RedirectToAction("RegisterComment", "Usuario");
                        }
            }   
            return RedirectToAction("RegisterUser", "Usuario");
        }*/

        public IActionResult Logout() 
        {
            HttpContext.Session.Remove(SessionEmail);
            HttpContext.Session.Remove(SessionUsuario);
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}