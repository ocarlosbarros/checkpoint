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
            string linha = $"ID={controleID};nome={comentario.Usuario.Nome};comentario={comentario.TextoComentario};data_criacao={comentario.DataCriacao.ToShortDateString()};status={comentario.Status}\n";

            return linha;
        }

        public List<Comentario> Listar()
        {
            var linhas = ObterRegistrosCSV(PATH);

            foreach (var item in linhas)
            {
                if(item != "")
                {
                    Comentario comentario = ConverterEmObjeto(item);
                    this.comentariosList.Add(comentario);
                }
            }
            return this.comentariosList;
        }

        private Comentario ConverterEmObjeto(string registro)
        {
            Usuario usuario = new Usuario();
            Comentario comentario = new Comentario();
            comentario.Usuario = usuario;
            
            Console.WriteLine("REGISTRO" + registro);
            comentario.ID = int.Parse(ExtrairCampo("ID", registro));
            comentario.Usuario.Nome = ExtrairCampo("nome", registro);
            comentario.TextoComentario = ExtrairCampo("comentario", registro);
            comentario.DataCriacao = DateTime.Parse(ExtrairCampo("data_criacao", registro));
            comentario.Status = bool.Parse(ExtrairCampo("status", registro));

            return comentario;
        }

    }
}