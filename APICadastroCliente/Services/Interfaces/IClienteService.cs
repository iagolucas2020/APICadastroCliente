
using APICadastroCliente.Models;

namespace APICadastroCliente.API.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAsync();
        Task<IEnumerable<Cliente>> GetFilterAsync(int? id, string? cpf, string? nome, string? email);
        Task<Cliente> GetByIdAsync(int id);
        Task<Cliente> PostAsync(Cliente cliente);
        Task<Cliente> PutAsync(Cliente cliente);
        Task Delete(Cliente cliente);
        Task GerarPdf(string path);
    }
}
