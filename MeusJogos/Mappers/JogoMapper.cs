using AutoMapper;
using MeusJogos.Domain.Entities;
using MeusJogos.Models;

namespace MeusJogos.Mappers
{
    public class JogoMapper : Profile
    {
        public JogoMapper()
        {
            CreateMap<JogoViewModel, Jogo>();
            CreateMap<Jogo, JogoViewModel>();
        }
    }
}