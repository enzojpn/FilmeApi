using AutoMapper;
using FilmeApi.Data;
using FilmeApi.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FilmeApi.Data.Dtos;

namespace FilmeApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private FilmeContext _context;

        private IMapper _mapper;

        public GerenteController(FilmeContext context, IMapper mapper)

        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult buscar(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null)
            {
                return NotFound();
            }

            return Ok(gerente);
        }

        [HttpPost]
        public IActionResult adicionar([FromBody] CreateGerenteDto gerenteDto)
        {

            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);
            _context.Add(gerente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(buscar), new { Id = gerente.Id }, gerente);
        }


    }
}