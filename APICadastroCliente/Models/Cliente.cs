using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICadastroCliente.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        [Required]
        [StringLength(80)]
        public string? Nome { get; set; }
        [Required]
        [StringLength(11)]
        public string? Cpf { get; set; }
        [Required]
        [StringLength(20)]
        public string? Rg { get; set; }
        [Required]
        public DateTime? DataNascimento { get; set; }
        [Required]
        [StringLength(300)]
        public string? Ocupacao { get; set; }
        [Required]
        [StringLength(80)]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string? Email { get; set; }
        [Required]
        public DateTime DataCadastro { get; set; }
        public int EnderecoId { get; set; }
        public Endereco? Endereco { get; set; }
    }
}
