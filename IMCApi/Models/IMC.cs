using System;

namespace IMCApi.Models
{
    public class IMC
    {
        public IMC() { }
        public IMC(int id, double peso, double altura, double imcUsuario, string classificacaoFormatada, int classificacao, int usuarioid, Usuario usuario, DateTime datacriacao)
        {
            this.Id = id;
            this.Peso = peso;
            this.Altura = altura;
            this.ImcUsuario = imcUsuario;
            this.Classificacao = classificacao;
            this.UsuarioId = usuarioid;
            this.Usuario = usuario;
            this.DataCriacao = datacriacao;
            this.ClassificacaoFormatada = classificacaoFormatada;
        }
        public int Id { get; set; }
        public double Peso { get; set; }

        public double Altura { get; set; }

        public double ImcUsuario { get; set; }
        public int UsuarioId { get; set; }

        public int Classificacao { get; set; }

        public Usuario Usuario { get; set; }

        public DateTime DataCriacao { get; set; }

        public string ClassificacaoFormatada { get; set; }

    }

}