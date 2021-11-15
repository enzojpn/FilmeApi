using AutoMapper;
using FilmeApi.Data.Dtos;
using FilmeApi.Data;
using FilmeApi.Models;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;

namespace FilmeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;
        public CinemaController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult adiciona([FromBody] CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(buscar), new { Id = cinema.Id }, cinema);
        }


        [HttpGet]
        public IEnumerable<Cinema> listar()
        {
            return _context.Cinemas;
        }

        [HttpGet("{id}")]
        public IActionResult buscar(int id)
        {

            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }

            return Ok(cinema);
        }

    }
}