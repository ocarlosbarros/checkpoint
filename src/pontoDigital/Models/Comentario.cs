using System;

namespace pontoDigital.Models
{
    public class Comentario
    {
        public int ID { get; set; }
        public Usuario Usuario {get;set;}
        public string textoComentario   {get;set;}
        public DateTime dataCriacao { get; set; }
    }
}