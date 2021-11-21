using System;
using System.Collections.Generic;
using FilmeApi.Models;

namespace FilmeApi.Data.Dtos
{
    public class ReadGerenteDto
    {

        public int Id { get; set; }
        public string Nome { get; set; }

        public Object Cinemas { get; set; }

        public DateTime HoraDaConsulta { get; set; }
    }
}