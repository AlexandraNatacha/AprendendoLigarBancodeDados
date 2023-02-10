using AprendendoLigarBancodeDados.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AprendendoLigarBancodeDados.Contexto
{
    public class BancoDeDados : DbContext
    {
        public BancoDeDados(DbContextOptions<BancoDeDados> options) : base(options)
        {
        }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Produto> Produto { get; set; }
    }
}
