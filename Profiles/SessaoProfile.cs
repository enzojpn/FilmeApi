using AutoMapper;
using FilmeApi.Data.Dtos.Sessao;
using FilmeApi.Models;

namespace FilmeApi.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap< CreateSessaoDto , Sessao>();
            CreateMap< Sessao , ReadSessaoDto>()
            .ForMember(dto => dto.HorarioDeInicio, opts => opts.
            MapFrom(dto => dto.HorarioDeEncerramento.AddMinutes(dto.Filme.Duracao*(-1))));
        }
    }
}