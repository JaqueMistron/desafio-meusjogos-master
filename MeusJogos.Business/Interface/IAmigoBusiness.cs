using MeusJogos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusJogos.Business.Interface
{
    public interface IAmigoBusiness
    {
        List<Amigo> ListarAmigos(string nome);
        Amigo BuscarAmigo(int? id);
        void Salvar(Amigo amigo);
        void Excluir(int id);
    }
}
