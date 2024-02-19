using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CheckPoint.Enums;
using CheckPoint.Interfaces;
using CheckPoint.Models;

namespace CheckPoint.Controllers
{
    public class UserController : Controller
    {
        private const string SESSION_EMAIL = "_EMAIL";
        private const string SESSION_USUARIO = "_USUARIO";

        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }

       [HttpPost]
        public IActionResult RegisterUser([FromServices] IUserService userService,IFormCollection frmCadastrarUsuario)
        {
            
            var user = new User
            (
            name: frmCadastrarUsuario["nome"],
            gender: frmCadastrarUsuario["genero"],
            dateOfBirth: DateTime.Parse(frmCadastrarUsuario["dataNascimento"]),
            address: frmCadastrarUsuario["endereco"],
            email: frmCadastrarUsuario["email"],
            telephone: frmCadastrarUsuario["telefone"],
            password:frmCadastrarUsuario["senha"]

            );
            
            user.Permission = (EnumPermission) Enum.Parse(typeof(EnumPermission),frmCadastrarUsuario["permissao"]);
            userService.CreateUser(user);
            
            ViewBag.titulo = "Cadastro";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult RegisterComment()
        {
            ViewData["User"] = HttpContext.Session.GetString(SESSION_USUARIO);
            ViewData["NomeView"] = "Cadastrar Comment";
            return View();
        }

        [HttpPost]
        public IActionResult RegisterComment(IFormCollection frmAddComentario)
        {
            User usuario = new User();
            usuario.Name = frmAddComentario["nome"];
            
            Comment comment = new Comment(
                textoComentario: frmAddComentario["comment"]
            );
            comment.User = usuario;

            /*
            comentarioRepository.AdicionarComentario(comment);
            */
            return View();
        }
    }
}