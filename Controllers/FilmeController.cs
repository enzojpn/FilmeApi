using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmeApi.Data.Dtos;
using FilmeApi.Data;
using FilmeApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;

        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
                filmeDto.HoraConsulta = DateTime.Now;
                return Ok(filmeDto);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult adiciona([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(buscar), new { Id = filme.Id }, filme);
        }

        [HttpPut("{id}")]
        public IActionResult altera(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return null;
            }
            _mapper.Map(filmeDto, filme);
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
