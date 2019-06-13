using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pontoDigital.Enums;
using pontoDigital.Repository;

namespace pontoDigital.Controllers
{
    public class LoginController : Controller
    {
        #region "Import" repositories
        private UsuarioRepository usuarioRepository = new UsuarioRepository();
        #endregion

        private const string SESSION_EMAIL = "_EMAIL";
        private const string SESSION_USUARIO = "_USUARIO";
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

            var usuario = usuarioRepository.BuscarPor(email);

            if(usuario != null && usuario.Senha.Equals(senha))
            {
                if ( usuario.Permissao.Equals(EnumPermissao.ADMNISTRADOR))
                    {
                        HttpContext.Session.SetString(SESSION_EMAIL, email);
                        HttpContext.Session.SetString(SESSION_USUARIO, usuario.Nome); 
                        
                        return RedirectToAction("Index", "Dashboard");

                    }else
                        {
                            HttpContext.Session.SetString(SESSION_EMAIL, email);
                            HttpContext.Session.SetString(SESSION_USUARIO, usuario.Nome); 
                            
                            return RedirectToAction("CadastrarComentario", "Usuario");
                        }
            }   
            return RedirectToAction("CadastrarUsuario", "Usuario");
        }
    }
}