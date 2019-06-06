using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pontoDigital.Models;
using pontoDigital.Repository;

namespace pontoDigital.Controllers
{
    public class UsuarioController : Controller
    {
        #region "Imports" do Repository
        private UsuarioRepository usuarioRepository = new UsuarioRepository();
        
        #endregion

        #region Rotas da Aplicação
        [HttpGet]
        public IActionResult Index()
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
            permissao: frmCadastrarUsuario["permissao"],
            email: frmCadastrarUsuario["email"],
            telefone: frmCadastrarUsuario["telefone"],
            senha:frmCadastrarUsuario["senha"]

            );//Fim do construtor

            usuarioRepository.Cadastrar(usuario);

            ViewBag.titulo = "Cadastro";
            return View();
        }
        #endregion
        
    }
}