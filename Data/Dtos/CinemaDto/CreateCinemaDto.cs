using System.ComponentModel.DataAnnotations;

namespace FilmeApi.Data.Dtos
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "Nome do cinema é obrigatório")]
        public string nome { get; set; }
        public int enderecoId { get; set; }
        public int gerenteId { get; set; }
    }
}