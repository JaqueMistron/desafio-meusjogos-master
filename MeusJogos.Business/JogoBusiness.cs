using MeusJogos.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeusJogos.Domain.Entities;
using MeusJogos.DataAccess;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace MeusJogos.Business
{
    public class JogoBusiness : IJogoBusiness
    {
        public MeusJogosContext _dbContext { get; set; }

        public List<Jogo> BuscarJogosDisponiveis(string nomeUsuario)
        {
            var jogosDisponiveis = _dbContext.Jogos
               .Include(x => x.ListaJogosEmprestados)
               .Include(x => x.Usuario)
               .Where(x => !x.ListaJogosEmprestados.Any() && string.Equals(x.Usuario.Nome, nomeUsuario))
               .ToList();
            return jogosDisponiveis;
        }

        public Jogo BuscarPorId(int id)
        {
            var jogo = _dbContext.Jogos.Include(x => x.ListaJogosEmprestados.Select(y => y.Amigo))
                     .FirstOrDefault(x => x.IdJogo == id);
            jogo.ListaJogosEmprestados.ForEach(x => { x.Amigo.ListaJogosEmprestados = null; x.Jogo = jogo; });
            return jogo;
        }
        
        public void Excluir(int id)
        {
            var jogo = BuscarPorId(id);
            _dbContext.Jogos.Remove(jogo);
            _dbContext.SaveChanges();
        }

        public List<Jogo> ListarJogos(string nomeUsuario)
        {
            var lista = _dbContext.Jogos
               .Include(x => x.Usuario)
               .Where(x => string.Equals(x.Usuario.Nome, nomeUsuario))
               .ToList();
            return lista;
        }

        public void Salvar(Jogo jogo)
        {
            _dbContext.Jogos.AddOrUpdate(jogo);
            _dbContext.SaveChanges();
        }
    }
}
