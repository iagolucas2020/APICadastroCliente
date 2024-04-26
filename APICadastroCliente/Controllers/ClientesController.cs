using APICadastroCliente.API.Repositories.Interfaces;
using APICadastroCliente.Context;
using APICadastroCliente.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICadastroCliente.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> Get()
        {
            try
            {
                var clientes = await _clienteRepository.GetAsync();
                if (clientes is null)
                    return NotFound();
                return clientes.ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Cliente cliente)
        {
            try
            {
                if (cliente is null)
                    return BadRequest("Invalid data!");

                await _clienteRepository.PostAsync(cliente);

                return new CreatedAtRouteResult("GetMerchandise", new { id = cliente.ClienteId }, cliente);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Cliente cliente)
        {
            try
            {
                if (id != cliente.ClienteId)
                    return BadRequest("Invalid data!");

                await _clienteRepository.PutAsync(cliente);

                return Ok(cliente);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var merchandise = await _clienteRepository.GetByIdAsync(id);
                if (merchandise is null)
                    return NotFound($"Id: {id} not found!");

                await _clienteRepository.Delete(merchandise);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }
        }
    }
}
