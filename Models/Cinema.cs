using System.ComponentModel.DataAnnotations;

namespace FilmeApi.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome do cinema é obrigatório")]
        public string Nome { get; set; }

        public virtual Endereco Endereco { get; set; }

        public int EnderecoId { get; set; }
    }
}