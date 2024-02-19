using System;
using System.Collections.Generic;
using System.IO;
using CheckPoint.Models;

namespace CheckPoint.Repository
{
    public class ComentarioRepository : BaseRepository
    {
        private const string PATH = "Data/Comentarios.csv";
        private const string PATH_INDEX = "Data/Comentario_Id.csv";
        private uint controleID = 0;
        private List<Comment> comentariosList = new List<Comment>();
        
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
        public bool AdicionarComentario(Comment comment)
        {
            controleID++;
            File.WriteAllText(PATH_INDEX, controleID.ToString());

            string linhaGravar = CriarCSV(comment);

            File.AppendAllText(PATH, linhaGravar);
            
            return true;
        }

        private string CriarCSV(Comment comment)
        {
            //comment.dataCriacao = DateTime.Now;
            string linha = $"ID={controleID};nome={comment.User.Name};comment={comment.TextoComentario};data_criacao={comment.DataCriacao.ToShortDateString()};status={comment.Status}\n";

            return linha;
        }

        public List<Comment> Listar()
        {
            var linhas = ObterRegistrosCSV(PATH);

            foreach (var item in linhas)
            {
                if(item != "")
                {
                    Comment comment = ConverterEmObjeto(item);
                    this.comentariosList.Add(comment);
                }
            }
            return this.comentariosList;
        }

        private Comment ConverterEmObjeto(string registro)
        {
            User usuario = new User();
            Comment comment = new Comment();
            comment.User = usuario;
            
            Console.WriteLine("REGISTRO" + registro);
            comment.ID = int.Parse(ExtrairCampo("ID", registro));
            comment.User.Name = ExtrairCampo("nome", registro);
            comment.TextoComentario = ExtrairCampo("comment", registro);
            comment.DataCriacao = DateTime.Parse(ExtrairCampo("data_criacao", registro));
            comment.Status = bool.Parse(ExtrairCampo("status", registro));

            return comment;
        }

        public Comment BuscarPor(int id)
        {
            foreach (var item in ObterRegistrosCSV(PATH))
            {
                if(id.ToString().Equals(ExtrairCampo("ID", item)))
                {
                    return ConverterEmObjeto(item);
                }
            }
            return null;
        }
    
        public bool Editar(Comment comment)
        {
            var comentariosRecuperados = ObterRegistrosCSV(PATH);
            var comentarioEditado = CriarCSV(comment);
            var linhaUsuario = -1;
            var resultado = false;

            for(int i = 0; i < comentariosRecuperados.Length; i++)
            {
                if (comment.ID.ToString().Equals(ExtrairCampo("ID", comentariosRecuperados[i])))
                {
                    linhaUsuario = i;
                    resultado = true;
                }
            }
            if (linhaUsuario >= 0)
            {
                comentariosRecuperados[linhaUsuario] = comentarioEditado;
                File.WriteAllLines(PATH, comentariosRecuperados);
            }
            return resultado;
        }

        public bool Excluir(int id)
        {
           var comentarioRecuperados = ObterRegistrosCSV(PATH);
            var linhaComentario = -1;
            var resultado = false;
            
            for (int i = 0; i < comentarioRecuperados.Length; i++)
            {
                if(id.ToString().Equals(ExtrairCampo("ID", comentarioRecuperados[i])))
                {
                    linhaComentario = i;
                    resultado = true;
                }
            }
            if (linhaComentario >= 0)
            {
                comentarioRecuperados[linhaComentario] = "";
                File.WriteAllLines(PATH, comentarioRecuperados);
            }

           return resultado;  
        }

        public bool Aprovar(Comment comment)
        {
            var comentariosRecuperados = ObterRegistrosCSV(PATH);
            var comentarioAprovado = CriarCSV(comment);
            var linhaComentario = -1;
            var resultado = false;

            for(int i = 0; i < comentariosRecuperados.Length; i++)
            {
                if (comment.ID.ToString().Equals(ExtrairCampo("ID", comentariosRecuperados[i])))
                {
                    linhaComentario = i;
                    resultado = true;
                }
            }
            if (linhaComentario >= 0)
            {
                comentariosRecuperados[linhaComentario] = comentarioAprovado;
                File.WriteAllLines(PATH, comentariosRecuperados);
            }
            return resultado;
        }
    }
}
