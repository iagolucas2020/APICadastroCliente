using APICadastroCliente.API.Repositories.Interfaces;
using APICadastroCliente.Context;
using APICadastroCliente.Models;
using Microsoft.EntityFrameworkCore;

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
            return await _context.Clientes.ToListAsync();
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
