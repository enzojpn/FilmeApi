using System;
using System.ComponentModel.DataAnnotations;

namespace FilmeApi.Data.Dtos
{
    public class ReadCinemaDto
    {
        [Required(ErrorMessage = "Nome do cinema é obrigatório")]
        public string nome { get; set; }

        public DateTime HoraConsulta { get; set; }
    }
}