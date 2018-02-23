using AutoMapper;
using MeusJogos.Domain.Entities;
using MeusJogos.Models;

namespace MeusJogos.Mappers
{
    public class AmigoMapper : Profile
    {
        public AmigoMapper()
        {
            CreateMap<AmigoViewModel, Amigo>();
        }
    }
}