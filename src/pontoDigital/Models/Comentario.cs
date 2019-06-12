using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System;

namespace pontoDigital.Models
{
    public class Comentario
    {
        public int ID { get; set; }
        public Usuario Usuario {get;set;}
        public string TextoComentario   {get;set;}
        public DateTime DataCriacao { get; set; }
        public bool Status {get;set;}


        public Comentario(string textoComentario)
        {
            this.TextoComentario = textoComentario;
            this.DataCriacao = DateTime.Now;
            this.Status = false;
        }
    }
}