using System.Collections.Generic;
using System.IO;
using pontoDigital.Models;

namespace pontoDigital.Repository
{
    public class UsuarioRepository
    {
        private const string PATH = "Data/usuarios.csv";//Caminho onde serão salvo os arquivos da aplicação
        private List<Usuario> usuariosList = new List<Usuario>();

        private int controlaID = 0;
        public void Cadastrar(Usuario usuario)
        {
            //Verificando se determinado caminho existe
            if(!File.Exists(PATH))
            {
                var diretorio = File.Create(PATH);
                
                diretorio.Close();//Fechando o stream de criação de diretorio e arquivo
            }
            
            usuario.ID = controlaID;

            string gravarLinha = $"{usuario.ID};{usuario.Nome};{usuario.Genero};{usuario.DataNascimento}{usuario.Endereco};{usuario.Telefone};{usuario.Email};{usuario.Senha}";
            
        }
    }
}