﻿namespace APICadastroCliente.Models
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
    }
}
