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
    public class EnderecoController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;
        public EnderecoController(FilmeContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult adiciona([FromBody] CreateEnderecoDto enderecoDto){
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            
            _context.Add(endereco);
            _context.SaveChanges();

            //TODO CreateAtAction -> GET
            return Ok();
        }

        [HttpGet]
        public IEnumerable<Endereco> listar(){
            return _context.Enderecos;
        }

        [HttpGet("{id}")]
        public IActionResult buscar(int id){

            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null){

            return NotFound();
            }

            return Ok(endereco);
        }

    }
}