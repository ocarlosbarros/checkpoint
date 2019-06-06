using System.Collections.Generic;
using System.IO;
using pontoDigital.Models;

namespace pontoDigital.Repository
{
    public class UsuarioRepository
    {
        private const string PATH = "Data/Usuarios.csv";//Caminho onde serão salvo os arquivos da aplicação
        private const string PATH_INDEX = "Data/Cliente_Id.csv";
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
            string linha = $"ID={controleID};nome={usuario.Nome};genero={usuario.Genero};data_nascimento={usuario.DataNascimento};endereco={usuario.Endereco};telefone={usuario.Telefone};permissao={usuario.Permissao};email={usuario.Email};senha={usuario.Senha}\n";

            return linha;
        }
    }
}