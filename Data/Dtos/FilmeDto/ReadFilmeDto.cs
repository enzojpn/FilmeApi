using System;
using System.ComponentModel.DataAnnotations;

namespace FilmeApi.Data.Dtos
{
    public class ReadFilmeDto
    { 
        public string Titulo { get; set; }
   
        public string Diretor { get; set; }
 
        public string Genero { get; set; }
 
        public int Duracao { get; set; }
 
        public int FaixaEtaria { get; set; }
        public DateTime HoraConsulta { get; set; }
    }
}