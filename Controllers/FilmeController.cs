using System;
using System.Collections.Generic;
using System.Linq;
using FilmesApi.Data;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult buscar()
        {
            return Ok(_context.Filmes);
        }

        [HttpGet("{id}")]
        public IActionResult buscar(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult adiciona([FromBody] Filme filme)
        {

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(buscar), new { Id = filme.Id }, filme);
        }

        [HttpPut("{id}")]
        public IActionResult altera(int id, [FromBody] Filme filmeNovo)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return null;
            }
            filme.Diretor = filmeNovo.Diretor;
            filme.Duracao = filmeNovo.Duracao;
            filme.Genero = filmeNovo.Genero;
            filme.Titulo = filmeNovo.Titulo;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id){
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null){
                return NotFound();
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
