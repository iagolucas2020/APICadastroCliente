
using APICadastroCliente.API.Repositories.Interfaces;
using APICadastroCliente.API.Services.Interfaces;
using APICadastroCliente.Models;

namespace APICadastroCliente.API.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> GetAsync()
        {
            try
            {
                return await _clienteRepository.GetAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Cliente>> GetFilterAsync(int? id, string? cpf, string? nome, string? email)
        {
            try
            {
                return await _clienteRepository.GetFilterAsync(id, cpf, nome, email);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            try
            {
                return await _clienteRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Cliente> PostAsync(Cliente cliente)
        {
            try
            {
                return await _clienteRepository.PostAsync(cliente);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Cliente> PutAsync(Cliente cliente)
        {
            try
            {
                return await _clienteRepository.PutAsync(cliente);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task Delete(Cliente cliente)
        {
            try
            {
                await _clienteRepository.Delete(cliente);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
