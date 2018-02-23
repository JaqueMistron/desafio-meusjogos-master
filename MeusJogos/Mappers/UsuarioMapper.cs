using AutoMapper;
using MeusJogos.Domain.Entities;
using MeusJogos.Models;

namespace MeusJogos.Mappers
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<UsuarioViewModel, Usuario>();
        }
    }
}