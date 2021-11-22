using System;
using System.ComponentModel.DataAnnotations;

namespace FilmeApi.Data.Dtos.Sessao
{
    public class CreateSessaoDto
    { 

        public int CinemaId { get; set; }

        public int FilmeId { get; set; }

        public DateTime HorarioDeEncerramento { get; set; }
    }
}