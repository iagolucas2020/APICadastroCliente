using APICadastroCliente.API.Repositories.Interfaces;
using APICadastroCliente.Context;
using APICadastroCliente.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace APIInventoryManagement.API.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAsync()
        {
            return await _context.Clientes.Include(x => x.Endereco).ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> GetFilterAsync(int? id, string? cpf, string? nome, string? email)
        {
            try
            {
                var clientes = await _context.Clientes
                    .FromSqlRaw($"SELECT * FROM Clientes cl WHERE 1 = 1" + 
                    (id != null ? " AND cl.ClienteId = " + id : "") +
                    (cpf != null ? " AND cl.Cpf = '" + cpf + "'" : "") +
                    (nome != null ? " AND cl.Nome LIKE '%" + nome + "%'": "") +
                    (email != null ? " AND cl.Email = '" + email + "'" : "")
                    )
                    .Include(x => x.Endereco)
                    .ToListAsync();
                return clientes;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            var merchandise = await _context.Clientes.FindAsync(id);
            return merchandise;
        }

        public async Task<Cliente> PostAsync(Cliente cliente)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> PutAsync(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task Delete(Cliente cliente)
        {
            _context.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
