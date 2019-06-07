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
        #endregion

        #region Rotas da Aplicação
        [HttpGet]
        public IActionResult Index()
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
        #endregion
        
    }
}