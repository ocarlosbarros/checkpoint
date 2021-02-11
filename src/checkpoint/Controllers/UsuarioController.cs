using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using pontoDigital.Enums;
using pontoDigital.Models;
using pontoDigital.Repository;

namespace pontoDigital.Controllers
{
    public class UsuarioController : Controller
    {
        #region "Imports" do Repository
        private UsuarioRepository usuarioRepository = new UsuarioRepository();
        private ComentarioRepository comentarioRepository = new ComentarioRepository();
        
        private const string SESSION_EMAIL = "_EMAIL";
        private const string SESSION_USUARIO = "_USUARIO";

        #endregion

        #region Rotas da Aplicação
        [HttpGet]
        public IActionResult CadastrarUsuario()
        {
            return View();
        }

       [HttpPost]
        public IActionResult CadastrarUsuario(IFormCollection frmCadastrarUsuario)
        {
            
            Usuario usuario = new Usuario
            (
            nome: frmCadastrarUsuario["nome"],
            genero: frmCadastrarUsuario["genero"],
            dataNascimento: DateTime.Parse(frmCadastrarUsuario["dataNascimento"]),
            endereco: frmCadastrarUsuario["endereco"],
            email: frmCadastrarUsuario["email"],
            telefone: frmCadastrarUsuario["telefone"],
            senha:frmCadastrarUsuario["senha"]

            );//Fim do construtor
            usuario.Permissao = (EnumPermissao) Enum.Parse(typeof(EnumPermissao),frmCadastrarUsuario["permissao"]);
            usuarioRepository.Cadastrar(usuario);

            ViewBag.titulo = "Cadastro";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult CadastrarComentario()
        {
            ViewData["User"] = HttpContext.Session.GetString(SESSION_USUARIO);
            ViewData["NomeView"] = "Cadastrar Comentario";
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarComentario(IFormCollection frmAddComentario)
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
        #endregion
    }
}