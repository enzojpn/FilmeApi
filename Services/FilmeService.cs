

using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmeApi.Data;
using FilmeApi.Data.Dtos;
using FilmeApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmeApi.Services
{
    public class FilmeService
    {

        private FilmeContext _context;

        private IMapper _mapper;

        public FilmeService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        internal ReadFilmeDto adiciona(CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return _mapper.Map<ReadFilmeDto>(filme);
        }

        internal List<ReadFilmeDto> buscarLista(int? faixaEtaria)
        {
            List<Filme> filmes;
            if (faixaEtaria != null)
            {
                filmes = _context.Filmes.Where(filme => filme.FaixaEtaria <= faixaEtaria).ToList();

            }
            else
            {
                filmes = _context.Filmes.ToList();
            }
            return _mapper.Map<List<ReadFilmeDto>>(filmes);
        }

        internal ReadFilmeDto buscarPorId(int id)
        {
             Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

             return _mapper.Map<ReadFilmeDto>(filme);
        }

        internal bool altera(int id, UpdateFilmeDto filmeDto)
        {
               Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null)
            {
                return false;
            }
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return true;
        }

        internal bool delete(int id)
        {
             Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return false;
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return true;
        }
    }
}