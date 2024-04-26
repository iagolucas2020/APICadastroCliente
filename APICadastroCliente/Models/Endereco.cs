using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICadastroCliente.Models
{
    [Table("Enderecos")]
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }
        [Required]
        [StringLength(200)]
        public string? Logradouro { get; set; }
        [Required]
        [StringLength(18)]
        public string? Numero { get; set; }
        [Required]
        [StringLength(30)]
        public string? Cidade { get; set; }
        [Required]
        [StringLength(30)]
        public string? Estado { get; set; }
    }
}
