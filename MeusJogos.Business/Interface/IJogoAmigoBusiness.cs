using MeusJogos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusJogos.Business.Interface
{
    public interface IJogoAmigoBusiness
    {
        void Excluir(int idAmigo, int idJogo, string nomeUsuario);
        List<JogoAmigo> ListarJogosEmprestados(string nomeUsuario);
        void Salvar(JogoAmigo emprestimo);
        List<Amigo> BuscarAmigos(string nomeUsuario);
        List<Jogo> BuscarJogosDisponiveis(string nomeUsuario);
        JogoAmigo BuscarJogosEmprestadosPorUsuario(int idAmigo, int idJogo, string nomeUsuario);
        List<JogoAmigo> ListarUltimosJogosEmprestados(int qtdade, string nomeUsuario);
    }
}
