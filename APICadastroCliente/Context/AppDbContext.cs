using APICadastroCliente.Models;
using Microsoft.EntityFrameworkCore;

namespace APICadastroCliente.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<Endereco>? Enderecos { get; set; }
    }
}
