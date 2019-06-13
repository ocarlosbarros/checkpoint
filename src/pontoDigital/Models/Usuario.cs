using System;
using pontoDigital.Enums;

namespace pontoDigital.Models
{
    public class Usuario
    {
        #region Propriedades
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public EnumPermissao Permissao {get;set;}
        #endregion

        #region Construtores
        public Usuario(){}//Construtor Default
        
        //Construtor inicializando Propriedades exceto ID
        public Usuario(string nome, string genero, DateTime dataNascimento, string endereco, string telefone, string email, string senha)
        {
            this.Nome = nome;
            this.Genero = genero;
            this.DataNascimento = dataNascimento;
            this.Endereco = endereco;
            this.Telefone = telefone;
            this.Email = email;
            this.Senha = senha;
        }

         public Usuario(int id, string nome, string genero, DateTime dataNascimento, string endereco, string telefone, string permissao, string email, string senha)
        {
            this.ID = id;
            this.Nome = nome;
            this.Genero = genero;
            this.DataNascimento = dataNascimento;
            this.Endereco = endereco;
            this.Telefone = telefone;
            this.Permissao = (EnumPermissao) Enum.Parse(typeof(EnumPermissao), permissao, true);
            this.Email = email;
            this.Senha = senha;
        }
        #endregion


        #region Métodos
        public void AprovarComentario(Comentario comentario)
        {
            comentario.Status = !comentario.Status;
        }
        #endregion
    }
}