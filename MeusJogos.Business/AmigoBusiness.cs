using MeusJogos.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using MeusJogos.Domain.Entities;
using MeusJogos.DataAccess;
using System.Data.Entity;

namespace MeusJogos.Business
{
    public class AmigoBusiness : IAmigoBusiness
    {
        public MeusJogosContext _dbContext { get; set; }

        public Amigo BuscarAmigo(int? id)
        {
            var objAmigo = _dbContext.Amigos
               .Include(x => x.ListaJogosEmprestados.Select(y => y.Jogo)) 
               .FirstOrDefault(x => x.IdAmigo == id.Value);

            objAmigo.ListaJogosEmprestados.ForEach(x => { x.Amigo = objAmigo; x.Jogo.ListaJogosEmprestados = null; });

            return objAmigo;
        }
        
        public void Excluir(int id)
        {
            var amigo = BuscarAmigo(id);
            _dbContext.Amigos.Remove(amigo);
            _dbContext.SaveChanges();
        }

        public List<Amigo> ListarAmigos(string nome)
        {
            var lista = _dbContext.Amigos
                .Include(x => x.Usuario)
                .Where(x => string.Equals(x.Usuario.Nome, nome))
                .ToList();
            return lista;
        }
        
        public void Salvar(Amigo amigo)
        {
            _dbContext.Amigos.AddOrUpdate(amigo);
            _dbContext.SaveChanges();
        }
    }
}