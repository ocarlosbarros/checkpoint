using System;
using System.Collections.Generic;
using System.IO;
using pontoDigital.Enums;
using pontoDigital.Models;

namespace pontoDigital.Repository
{
    public class UsuarioRepository : BaseRepository
    {
        private const string PATH = "Data/Usuarios.csv";//Caminho onde serão salvo os arquivos da aplicação
        private const string PATH_INDEX = "Data/Usuario_Id.csv";
        private uint controleID = 0;
        private List<Usuario> usuariosList = new List<Usuario>();

        #region Construtor
        public UsuarioRepository()
        {
            if(!File.Exists(PATH_INDEX))
            {
                var diretorio = File.Create(PATH_INDEX);
                diretorio.Close();//Fechando o stream de criação de diretorio e arquivo
            }

            var ultimaLinha = File.ReadAllText(PATH_INDEX);
            uint  linhaAtual = 0;
            uint.TryParse(ultimaLinha, out linhaAtual);

            controleID = linhaAtual;
        }
        #endregion
        public bool Cadastrar(Usuario usuario)
        {
            controleID++;
            File.WriteAllText(PATH_INDEX, controleID.ToString());

            string linhaGravar = CriarCSV(usuario);

            File.AppendAllText(PATH, linhaGravar);
            
            return true;
        }

        private string CriarCSV(Usuario usuario)
        {
            string linha = $"ID={controleID};nome={usuario.Nome};genero={usuario.Genero};data_nascimento={usuario.DataNascimento.ToShortDateString()};endereco={usuario.Endereco};telefone={usuario.Telefone};permissao={usuario.Permissao};email={usuario.Email};senha={usuario.Senha}\n";

            return linha;
        }
        public Usuario BuscarPor(string email)
        {
            foreach (var item in ObterRegistrosCSV(PATH))
            {
                if (email.Equals(ExtrairCampo("email", item)))
                {
                    return ConverterEmObjeto(item);
                }
            }

            return null;
        }

        public Usuario BuscarPor(int id)
        {
            foreach (var item in ObterRegistrosCSV(PATH))
            {
                if (id.ToString().Equals(ExtrairCampo("ID", item)))
                {
                    return ConverterEmObjeto(item);
                }
            }

            return null;
        }


        public bool Excluir(int id)
        {
            var usuariosRecuperados = ObterRegistrosCSV(PATH);
            var linhaUsuario = -1;
            var resultado = false;
            
            for (int i = 0; i < usuariosRecuperados.Length; i++)
            {
                if(id.ToString().Equals(ExtrairCampo("ID", usuariosRecuperados[i])))
                {
                    linhaUsuario = i;
                    resultado = true;
                }
            }
            if (linhaUsuario >= 0)
            {
                usuariosRecuperados[linhaUsuario] = "";
                File.WriteAllLines(PATH, usuariosRecuperados);
            }

           return resultado; 
        }
        
        private Usuario ConverterEmObjeto(string registro)
        {
            Usuario usuario = new Usuario();
            Console.WriteLine("REGISTRO" + registro);
            usuario.ID = int.Parse(ExtrairCampo("ID", registro));
            usuario.Nome = ExtrairCampo("nome", registro);
            usuario.Genero = ExtrairCampo("genero", registro);
            usuario.DataNascimento = DateTime.Parse(ExtrairCampo("data_nascimento", registro));
            usuario.Endereco = ExtrairCampo("endereco", registro);
            usuario.Permissao = (EnumPermissao) Enum.Parse(typeof(EnumPermissao),ExtrairCampo("permissao", registro));
            usuario.Email = ExtrairCampo("email", registro);
            usuario.Telefone = ExtrairCampo("telefone", registro);
            usuario.Senha = ExtrairCampo("senha", registro);

            return usuario;
        }

        public List<Usuario> Listar()
        {
            var linhas = ObterRegistrosCSV(PATH);

        
            foreach (var item in linhas)
            {
                if(item != "")
                {
                    Usuario usuario = ConverterEmObjeto(item);
                    this.usuariosList.Add(usuario);

                }
            }
            return this.usuariosList;
        }

        public bool Editar(Usuario usuario)
        {
            var usuariosRecuperados = ObterRegistrosCSV(PATH);
            var usuarioEditado = CriarCSV(usuario);
            var linhaUsuario = -1;
            var resultado = false;

            for(int i = 0; i < usuariosRecuperados.Length; i++)
            {
                if (usuario.ID.ToString().Equals(ExtrairCampo("ID", usuariosRecuperados[i])))
                {
                    linhaUsuario = i;
                    resultado = true;
                }
            }
            if (linhaUsuario >= 0)
            {
                usuariosRecuperados[linhaUsuario] = usuarioEditado;
                File.WriteAllLines(PATH, usuariosRecuperados);
            }
            return resultado;
        }
    }
}