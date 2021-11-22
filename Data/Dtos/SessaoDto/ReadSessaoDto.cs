using System;
using FilmeApi.Models;

namespace FilmeApi.Data.Dtos.Sessao
{    public class ReadSessaoDto
    { 
        public Cinema Cinema { get; set; }

        public Filme Filme { get; set; }

        public DateTime HorarioDeEncerramento { get; set; }
        public DateTime HorarioDeInicio { get; set; }
    }
}