using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IMCApi.Models
{
    public class DataContext : DbContext
    {
        // Estabelece conexão com o banco de dados
        // A options passado como base faz a parte de herança de atributos para o filho

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        // Métodos que permitem que a classe se torne uma tabela no sqlite
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<IMC> IMCs { get; set; }
        protected override void OnModelCreating(ModelBuilder builder) { }
    }
}