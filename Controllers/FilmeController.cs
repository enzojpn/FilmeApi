using System;
using System.Collections.Generic;
using System.Linq;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController
    {
        private static List<Filme> filmes = new List<Filme>();

        private static int count = 1;

        [HttpGet]
        public IEnumerable<Filme> buscar()
        {
            return filmes;
        }
        [HttpGet("{id}")]
        public Filme buscar(int id){
            return filmes.FirstOrDefault(filme => filme.Id == id);

        }


        [HttpPost]
        public void adiciona([FromBody] Filme filme)
        {
            filme.Id = count++;
            filmes.Add(filme);
            Console.WriteLine(filme.Titulo);
        }

    }
}