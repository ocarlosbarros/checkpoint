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
        
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["User"] = HttpContext.Session.GetString("SESSION_USUARIO");
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
            User usuario = new User
            (
            name: frmCadastrarUsuario["nome"],
            gender: frmCadastrarUsuario["genero"],
            dateOfBirth: DateTime.Parse(frmCadastrarUsuario["dataNascimento"]),
            address: frmCadastrarUsuario["endereco"],
            email: frmCadastrarUsuario["email"],
            telephone: frmCadastrarUsuario["telefone"],
            password:frmCadastrarUsuario["senha"]

            );//Fim do construtor
            usuario.Permission = (EnumPermission) Enum.Parse(typeof(EnumPermission),frmCadastrarUsuario["permissao"]);

            //useRepository.Cadastrar(usuario);

            ViewBag.titulo = "Cadastro";
            return View();
        }

        
        [HttpGet]
        public IActionResult ListarUsuario()
        {

           // ViewData["usuariosList"] = usuarioRepository.Listar();
           
            return View();
        }

        [HttpGet]
        public IActionResult EditarExcluirUsuario()
        {
            //ViewData["usuariosList"] = usuarioRepository.Listar();

            return View();
        }

        [HttpGet]
        public IActionResult EditarUsuario(int id)
        {
            //Usuario usuarioEditar = usuarioRepository.BuscarPor(id);

            /*if(usuarioEditar != null)
            {
                ViewBag.usuario = usuarioEditar;
            }else
                {
                    TempData["mensagem"] = "Não a usuário a ser editado!";

                    return RedirectToAction("ListarUsuario");
                }*/
            
            return View();
        }
        [HttpPost]
        public IActionResult Salvar(IFormCollection frmEditarUsuario)
        {
            User usuarioEditar = new User
            (
                id:int.Parse(frmEditarUsuario["id"]),
                name: frmEditarUsuario["nome"],
                gender: frmEditarUsuario["genero"],
                dateOfBirth: DateTime.Parse(frmEditarUsuario["dataNascimento"]),
                address: frmEditarUsuario["endereco"],
                permission: frmEditarUsuario["permissao"],
                email: frmEditarUsuario["email"],
                telephone: frmEditarUsuario["telefone"],
                password:frmEditarUsuario["senha"]
            );
            usuarioEditar.Permission = (EnumPermission) Enum.Parse(typeof(EnumPermission),frmEditarUsuario["permissao"]);

            //usuarioRepository.Editar(usuarioEditar);

            return RedirectToAction("ListarUsuario");
        }

        [HttpGet]
        public IActionResult ExcluirUsuario(int id)
        {

            //usuarioRepository.Excluir(id);
            
                    
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
            User usuario = new User();
            usuario.Name = frmAddComentario["nome"];
            
            Comment comment = new Comment(
                textoComentario: frmAddComentario["comment"]
            );
            comment.User = usuario;

            //comentarioRepository.AdicionarComentario(comment);

            return RedirectToAction("ListarComentario");
        }

        [HttpGet]
        public IActionResult ListarComentario()
        {
            //ViewData["comentariosList"] = comentarioRepository.Listar();

            return View();
        }

        [HttpGet]
        public IActionResult EditarExcluirComentario()
        {
            //ViewData["comentariosList"] = comentarioRepository.Listar();

            return View();
        }

        [HttpGet]
        public IActionResult EditarComentario(int id)
        {
            
            //Comment commentEditar = comentarioRepository.BuscarPor(id);

            if("commentEditar" != null)
            {
                ViewBag.comentario = "commentEditar";
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
            User usuario = new User();
            Comment commentEditar = new Comment();
            commentEditar.User = usuario;

            commentEditar.ID = int.Parse(frmEditarComentario["id"]);
            commentEditar.User.Name = frmEditarComentario["nome"];
            commentEditar.TextoComentario = frmEditarComentario["comment"];
            commentEditar.DataCriacao = DateTime.Parse(DateTime.Now.ToShortDateString());
            commentEditar.Status = false;
            
            //comentarioRepository.Editar(commentEditar);

            return RedirectToAction("ListarComentario");
        }

        [HttpGet]
        public IActionResult ExcluirComentario(int id)
        {

            //comentarioRepository.Excluir(id);
            
                    
            return RedirectToAction("ListarComentario");
               
        }

        [HttpGet]
        public IActionResult AprovarComentario()
        {
            //ViewData["comentariosList"] = comentarioRepository.Listar();


            return View();
        }

        [HttpGet]
        public IActionResult AprovarReprovar(int id)
        {
            //Comment commentAprovar = comentarioRepository.BuscarPor(id);
            User usuario = new User();
            
            //usuario.AprovarReprovarComentario(commentAprovar);
            
            //comentarioRepository.Aprovar(commentAprovar);

            return RedirectToAction("ListarComentario");
        }

    }
}