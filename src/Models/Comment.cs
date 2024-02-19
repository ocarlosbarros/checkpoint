using System;

namespace CheckPoint.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public User User {get;set;}
        public string TextoComentario   {get;set;}
        public DateTime DataCriacao { get; set; }
        public bool Status {get;set;}

        public Comment(){}
        public Comment(string textoComentario)
        {
            this.TextoComentario = textoComentario;
            this.DataCriacao = DateTime.Now;
            this.Status = false;
        }
    }
}