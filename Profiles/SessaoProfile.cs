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
            CreateMap< Sessao , ReadSessaoDto>();
        }
    }
}