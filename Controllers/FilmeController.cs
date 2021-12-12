using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmeApi.Data.Dtos;
using FilmeApi.Data;
using FilmeApi.Models;
using Microsoft.AspNetCore.Mvc;
using FilmeApi.Services;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeService _filmeService;
        public FilmeController(FilmeService filmeService)
        {
           _filmeService = filmeService;
        }

        [HttpGet]
        public IActionResult buscarLista([FromQuery] int? faixaEtaria = null)
        {
            
            List<ReadFilmeDto> filmesDto = _filmeService.buscarLista(faixaEtaria);            

            if (filmesDto != null)
            { 
                return Ok(filmesDto);
            }
 
            return NotFound();

        }

        [HttpGet("{id}")]
        public IActionResult buscarPorId(int id)
        {
           ReadFilmeDto  filmeDto= _filmeService.buscarPorId(id);
             if (  filmeDto != null)
            { 
                filmeDto.HoraConsulta = DateTime.Now;
                return Ok(filmeDto);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult adiciona([FromBody] CreateFilmeDto filmeDto)
        {

           ReadFilmeDto readDto =  _filmeService.adiciona(filmeDto);   
            
            return CreatedAtAction(nameof(buscarPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpPut("{id}")]
        public IActionResult altera(int id, [FromBody] UpdateFilmeDto filmeDto)
        { 

            if ( !_filmeService.altera(id, filmeDto) )
            {
                return NotFound();
            } 
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        { 
            
            if ( !_filmeService.delete(id) )
            {
                return NotFound();
            } 
            return NoContent();
        }

    }
}
