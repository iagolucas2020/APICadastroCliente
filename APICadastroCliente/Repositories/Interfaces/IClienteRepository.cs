using APICadastroCliente.Models;

namespace APICadastroCliente.API.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAsync();
        Task<Cliente> GetByIdAsync(int id);
        Task<Cliente> PostAsync(Cliente cliente);
        Task<Cliente> PutAsync(Cliente cliente);
        Task Delete(Cliente cliente);
    }
}
