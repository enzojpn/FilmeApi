using AutoMapper;
using FilmeApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmeApi.Profiles
{
    public class FilmeProfile : Profile
    {

        public FilmeProfile()
        {
            CreateMap< CreateFilmeDto, Filme>();
            CreateMap< UpdateFilmeDto, Filme>();
            CreateMap< Filme, ReadFilmeDto >();
        }
    }
}