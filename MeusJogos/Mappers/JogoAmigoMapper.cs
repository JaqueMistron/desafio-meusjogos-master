using AutoMapper;
using MeusJogos.Domain.Entities;
using MeusJogos.Models;

namespace MeusJogos.Mappers
{
    public class JogoAmigoMapper : Profile
    {
        public JogoAmigoMapper()
        {
            CreateMap<JogoAmigoViewModel, JogoAmigo>();
            CreateMap<JogoAmigo, JogoAmigoViewModel>();
        }
    }
}