using System;
using System.ComponentModel.DataAnnotations;
using FilmeApi.Models;

namespace FilmeApi.Data.Dtos
{
    public class ReadCinemaDto
    {
        public string nome { get; set; }
 
        public virtual Endereco Endereco { get; set; }
        public Gerente Gerente { get; set; }
        public DateTime HoraConsulta { get; set; }
    }
}