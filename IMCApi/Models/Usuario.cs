using System;

namespace IMCApi.Models
{
    public class Usuario
    {

        public Usuario() { }
        public Usuario(int id, string nome, DateTime nascimento)
        {
            this.Id = id;
            this.Nome = nome;
            this.Nascimento = nascimento;
        }
        public int Id { get; set; }
        public string Nome { get; set; }

        public DateTime Nascimento { get; set; }
    }

}