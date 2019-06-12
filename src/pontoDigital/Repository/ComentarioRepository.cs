using System;
using System.Collections.Generic;
using System.IO;
using pontoDigital.Models;

namespace pontoDigital.Repository
{
    public class ComentarioRepository : BaseRepository
    {
        private const string PATH = "Data/Comentarios.csv";
        private const string PATH_INDEX = "Data/Comentario_Id.csv";

        private uint controleID = 0;
        private List<Comentario> comentariosList = new List<Comentario>();
        
        #region Construtor
        public ComentarioRepository()
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
        public bool AdicionarComentario(Comentario comentario)
        {
            controleID++;
            File.WriteAllText(PATH_INDEX, controleID.ToString());

            string linhaGravar = CriarCSV(comentario);

            File.AppendAllText(PATH, linhaGravar);
            
            return true;
        }

        private string CriarCSV(Comentario comentario)
        {
            //comentario.dataCriacao = DateTime.Now;
            string linha = $"ID={controleID};nome={comentario.Usuario.Nome};comentario={comentario.TextoComentario};data_criacao={comentario.DataCriacao};status={comentario.Status}\n";

            return linha;
        }
    }
}