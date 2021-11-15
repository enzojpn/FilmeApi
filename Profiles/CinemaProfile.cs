using AutoMapper;
using FilmeApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmeApi.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<UpdateCinemaDto, Cinema>();
            CreateMap<Cinema, ReadFilmeDto>();
        }
    }
}