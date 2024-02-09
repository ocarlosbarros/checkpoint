using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CheckPoint.Enums;
using CheckPoint.Models;
using CheckPoint.Repository;

namespace CheckPoint.Controllers
{
    public class DashboardController : Controller
    {
        #region "Imports" do Repository
            private UsuarioRepository usuarioRepository = new UsuarioRepository();
            private ComentarioRepository comentarioRepository = new ComentarioRepository();

            private const string SESSION_EMAIL = "_EMAIL";
            private const string SESSION_USUARIO = "_USUARIO";
            
        #endregion

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["User"] = HttpContext.Session.GetString(SESSION_USUARIO);
            return View();
        }

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
            return View();
        }

        
        [HttpGet]
        public IActionResult ListarUsuario()
        {

            ViewData["usuariosList"] = usuarioRepository.Listar();
           
            return View();
        }

        [HttpGet]
        public IActionResult EditarExcluirUsuario()
        {
            ViewData["usuariosList"] = usuarioRepository.Listar();

            return View();
        }

        [HttpGet]
        public IActionResult EditarUsuario(int id)
        {
            Usuario usuarioEditar = usuarioRepository.BuscarPor(id);

            if(usuarioEditar != null)
            {
                ViewBag.usuario = usuarioEditar;
            }else
                {
                    TempData["mensagem"] = "Não a usuário a ser editado!";

                    return RedirectToAction("ListarUsuario");
                }
            
            return View();
        }
        [HttpPost]
        public IActionResult Salvar(IFormCollection frmEditarUsuario)
        {
            Usuario usuarioEditar = new Usuario
            (
                id:int.Parse(frmEditarUsuario["id"]),
                nome: frmEditarUsuario["nome"],
                genero: frmEditarUsuario["genero"],
                dataNascimento: DateTime.Parse(frmEditarUsuario["dataNascimento"]),
                endereco: frmEditarUsuario["endereco"],
                permissao: frmEditarUsuario["permissao"],
                email: frmEditarUsuario["email"],
                telefone: frmEditarUsuario["telefone"],
                senha:frmEditarUsuario["senha"]
            );
            usuarioEditar.Permissao = (EnumPermissao) Enum.Parse(typeof(EnumPermissao),frmEditarUsuario["permissao"]);

            usuarioRepository.Editar(usuarioEditar);

            return RedirectToAction("ListarUsuario");
        }

        [HttpGet]
        public IActionResult ExcluirUsuario(int id)
        {

            usuarioRepository.Excluir(id);
            
                    
            return RedirectToAction("ListarUsuario");
               
        }
        [HttpGet]
        public IActionResult CadastrarComentario()
        {
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

            return RedirectToAction("ListarComentario");
        }

        [HttpGet]
        public IActionResult ListarComentario()
        {
            ViewData["comentariosList"] = comentarioRepository.Listar();

            return View();
        }

        [HttpGet]
        public IActionResult EditarExcluirComentario()
        {
            ViewData["comentariosList"] = comentarioRepository.Listar();

            return View();
        }

        [HttpGet]
        public IActionResult EditarComentario(int id)
        {
            
            Comentario comentarioEditar = comentarioRepository.BuscarPor(id);

            if(comentarioEditar != null)
            {
                ViewBag.comentario = comentarioEditar;
            }else
                {
                    TempData["mensagem"] = "Não a comentário a ser editado!";

                    return RedirectToAction("ListarComentario");
                }
            
            return View();
        }

        [HttpPost]
         public IActionResult SalvarComentario(IFormCollection frmEditarComentario)
        {
            Usuario usuario = new Usuario();
            Comentario comentarioEditar = new Comentario();
            comentarioEditar.Usuario = usuario;

            comentarioEditar.ID = int.Parse(frmEditarComentario["id"]);
            comentarioEditar.Usuario.Nome = frmEditarComentario["nome"];
            comentarioEditar.TextoComentario = frmEditarComentario["comentario"];
            comentarioEditar.DataCriacao = DateTime.Parse(DateTime.Now.ToShortDateString());
            comentarioEditar.Status = false;
            
            comentarioRepository.Editar(comentarioEditar);

            return RedirectToAction("ListarComentario");
        }

        [HttpGet]
        public IActionResult ExcluirComentario(int id)
        {

            comentarioRepository.Excluir(id);
            
                    
            return RedirectToAction("ListarComentario");
               
        }

        [HttpGet]
        public IActionResult AprovarComentario()
        {
            ViewData["comentariosList"] = comentarioRepository.Listar();


            return View();
        }

        [HttpGet]
        public IActionResult AprovarReprovar(int id)
        {
            Comentario comentarioAprovar = comentarioRepository.BuscarPor(id);
            Usuario usuario = new Usuario();
            
            usuario.AprovarReprovarComentario(comentarioAprovar);
            
            comentarioRepository.Aprovar(comentarioAprovar);

            return RedirectToAction("ListarComentario");
        }

    }
}