namespace APICadastroCliente.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Rg { get; set; }
        public string? DataNascimento { get; set; }
        public string? Ocupacao { get; set; }
        public string? Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public int EnderecoId { get; set; }
        public Endereco? Endereco { get; set; }
    }
}
