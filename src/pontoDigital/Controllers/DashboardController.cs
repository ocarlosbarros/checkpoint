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
    public class DashboardController : Controller
    {
        #region "Imports" do Repository
            private UsuarioRepository usuarioRepository = new UsuarioRepository();
            private ComentarioRepository comentarioRepository = new ComentarioRepository();
        #endregion

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CadastrarUsuario()
        {
            //SelectListItem representa o  componente SELECT que será renderizado no html
            var permissoesList = new List<SelectListItem>();//Cria uma lista select
            
            //Adiciona os campos do SelectListItem
            permissoesList.Add(new SelectListItem
            {
                Text = "Select",
                Value = ""
            });

            //Populando o option com os valores do enum
            foreach (EnumPermissao valor in Enum.GetValues(typeof(EnumPermissao)))
            {
                permissoesList.Add(new SelectListItem { Text = Enum.GetName(typeof(EnumPermissao), valor), Value = valor.ToString() });
            }
            
            //Enviando a lista de permissoes para view
            ViewBag.Permissoes = permissoesList;
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(IFormCollection frmCadastrarUsuario)
        {
            //SelectListItem representa o  componente SELECT que será renderizado no html
            var permissoesList = new List<SelectListItem>();//Cria uma lista select
            
            //Adiciona os campos do SelectListItem
            permissoesList.Add(new SelectListItem
            {
                Text = "Select",
                Value = ""
            });

            //Populando o option com os valores do enum
            foreach (EnumPermissao valor in Enum.GetValues(typeof(EnumPermissao)))
            {
                permissoesList.Add(new SelectListItem { Text = Enum.GetName(typeof(EnumPermissao), valor), Value = valor.ToString() });
            }
            
            //Enviando a lista de permissoes para view
            ViewBag.Permissoes = permissoesList;

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

            usuarioRepository.Editar(usuarioEditar);

            return RedirectToAction("ListarUsuario");
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
    }
}