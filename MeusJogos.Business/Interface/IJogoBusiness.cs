using MeusJogos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusJogos.Business.Interface
{
    public interface IJogoBusiness
    {
        List<Jogo> ListarJogos(string nomeUsuario);
        Jogo BuscarPorId(int id);
        void Salvar(Jogo jogo);
        void Excluir(int id);
        List<Jogo> BuscarJogosDisponiveis(string nomeUsuario);
    }
}
