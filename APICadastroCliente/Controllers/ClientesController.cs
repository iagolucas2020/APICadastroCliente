﻿using APICadastroCliente.API.Repositories.Interfaces;
using APICadastroCliente.API.Services.Interfaces;
using APICadastroCliente.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace APICadastroCliente.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _cliente;
        private readonly IHostEnvironment _hostEnvironment;

        public ClientesController(IClienteService cliente, IHostEnvironment hostEnvironment)
        {
            _cliente = cliente;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> Get()
        {
            try
            {
                var clientes = await _cliente.GetAsync();
                if (clientes is null)
                    return NotFound();
                return clientes.ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }
        }

        [HttpGet("{id:int}", Name = "GetClientes")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            try
            {
                var cliente = await _cliente.GetByIdAsync(id);
                if (cliente is null)
                    return NotFound($"Id: {id} not found!");
                return cliente;
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

                await _cliente.PostAsync(cliente);

                return new CreatedAtRouteResult("GetClientes", new { id = cliente.ClienteId }, cliente);
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

                await _cliente.PutAsync(cliente);

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
                var cliente = await _cliente.GetByIdAsync(id);
                if (cliente is null)
                    return NotFound($"Id: {id} not found!");

                await _cliente.Delete(cliente);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }
        }

        [HttpGet("filtro")]
        public async Task<ActionResult<IEnumerable<Cliente>>> Get(int? id, string? cpf, string? nome, string? email)
        {
            try
            {
                var clientes = await _cliente.GetFilterAsync(id, cpf, nome, email);
                if (clientes is null)
                    return NotFound();
                return clientes.ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }

        }

        [HttpGet("pdf")]
        public async Task<IActionResult> GerarPdf()
        {
            try
            {
                string pathDirectory = _hostEnvironment.ContentRootPath;
                await _cliente.GerarPdf(pathDirectory);
                return PhysicalFile(String.Concat(pathDirectory, "wwwroot\\temp\\arquivo.pdf"), "application/pdf", "arquivo.pdf");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }
        }
    }
}
