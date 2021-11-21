using AutoMapper;
using FilmeApi.Data;
using FilmeApi.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FilmeApi.Data.Dtos;
using System;

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
            if (gerente != null)
            {
                ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);
                gerenteDto.HoraDaConsulta = DateTime.Now;
                return Ok(gerenteDto);
            }

            return NotFound();
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