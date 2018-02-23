using MeusJogos.Business.Interface;
using MeusJogos.DataAccess;
using MeusJogos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace MeusJogos.Business
{
    public class JogoAmigoBusiness : IJogoAmigoBusiness
    {
        public MeusJogosContext _dbContext { get; set; }
        public IAmigoBusiness _amigoBusiness { get; set; }
        public IJogoBusiness _jogoBusiness { get; set; }

        public List<Amigo> BuscarAmigos(string nomeUsuario)
        {
            return _amigoBusiness.ListarAmigos(nomeUsuario);
        }

        public List<Jogo> BuscarJogosDisponiveis(string nomeUsuario)
        {
            return _jogoBusiness.BuscarJogosDisponiveis(nomeUsuario);
        }

        public JogoAmigo BuscarJogosEmprestadosPorUsuario(int idAmigo, int idJogo, string nomeUsuario)
        {
            var jogosEmprestados = _dbContext.JogosEmprestados
                .Include(x => x.Jogo)
                .Include(x => x.Amigo)
                .Include(x => x.Usuario)
                .FirstOrDefault(x => x.IdAmigo == idAmigo && x.IdJogo == idJogo && string.Equals(x.Usuario.Nome, nomeUsuario));
            jogosEmprestados.Amigo.ListaJogosEmprestados = null;
            jogosEmprestados.Jogo.ListaJogosEmprestados = null;
            jogosEmprestados.Usuario.ListaJogosEmprestados = null;
            return jogosEmprestados;
        }

        public void Excluir(int idAmigo, int idJogo, string nomeUsuario)
        {
            var jogosEmprestados = BuscarJogosEmprestadosPorUsuario(idAmigo, idJogo, nomeUsuario);
            _dbContext.JogosEmprestados.Remove(jogosEmprestados);
            _dbContext.SaveChanges();
        }

        public List<JogoAmigo> ListarJogosEmprestados(string nomeUsuario)
        {
            var lista = _dbContext.JogosEmprestados
                .Include(x => x.Amigo)
                .Include(x => x.Jogo)
                .Include(x => x.Usuario)
                .Where(x => string.Equals(x.Usuario.Nome, nomeUsuario))
                .ToList();
            lista.ForEach(x =>
            {
                x.Amigo.ListaJogosEmprestados = null;
                x.Jogo.ListaJogosEmprestados = null;
                x.Usuario.ListaJogos = null;
                x.Usuario.ListaAmigos = null;
                x.Usuario.ListaJogosEmprestados = null;
            });
            return lista;
        }

        public List<JogoAmigo> ListarUltimosJogosEmprestados(int qtdade, string nomeUsuario)
        {
            var lista = _dbContext.JogosEmprestados
                .Include(x => x.Amigo)
                .Include(x => x.Jogo)
                .Include(x => x.Usuario)
                .OrderByDescending(x => x.DataRetirada)
                .Take(qtdade)
                .Where(x => string.Equals(x.Usuario.Nome, nomeUsuario))
                .ToList();
            lista.ForEach(x => { x.Amigo.ListaJogosEmprestados = null; x.Jogo.ListaJogosEmprestados = null; });
            return lista;
        }

        public void Salvar(JogoAmigo jogoEmprestado)
        {
            _dbContext.JogosEmprestados.AddOrUpdate(jogoEmprestado);
            _dbContext.SaveChanges();
        }
    }
}
