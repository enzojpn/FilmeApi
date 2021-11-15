using AutoMapper;
using FilmeApi.Data.Dtos;
using FilmeApi.Models;

namespace FilmeApi.Profiles
{
    public class EnderecoProfile : Profile
        {
       public EnderecoProfile()
       {
           CreateMap<UpdateEnderecoDto , Endereco>();
           CreateMap<CreateEnderecoDto , Endereco>();
           CreateMap<Endereco, ReadEnderecoDto>();
       }
    }
}