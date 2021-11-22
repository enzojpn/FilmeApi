using System.ComponentModel.DataAnnotations;
using FilmeApi.Models;

namespace FilmeApi.Data.Dtos
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "Nome do cinema é obrigatório")]
        public string nome { get; set; }

        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }

        public int GerenteId { get; set; }


    }
}