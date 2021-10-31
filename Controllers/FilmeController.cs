using System;
using System.Collections.Generic;
using System.Linq;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();

        private static int count = 1;

        [HttpGet]
        public IActionResult buscar()
        {
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public IActionResult buscar(int id)
        {
            Filme filme = filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult adiciona([FromBody] Filme filme)
        {
            filme.Id = count++;
            filmes.Add(filme);

            return CreatedAtAction(nameof(buscar), new { Id = filme.Id }, filme);
        }
    }
}
