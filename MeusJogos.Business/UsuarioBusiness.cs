using MeusJogos.Business.Interface;
using MeusJogos.DataAccess;
using MeusJogos.Domain.Entities;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MeusJogos.Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        public MeusJogosContext _dbContext { get; set; }
        
        public bool ValidarUsuario(Usuario usuario)
        {
            return _dbContext.Usuarios.Any(x => x.Nome == usuario.Nome && x.Senha == usuario.Senha);
        }

        public void Salvar(Usuario usuario)
        {
            _dbContext.Usuarios.AddOrUpdate(usuario);
            _dbContext.SaveChanges();
        }

        public bool VerificarUsuarioExistente(string nomeUsuario)
        {
            return _dbContext.Usuarios.Any(x => string.Equals(x.Nome, nomeUsuario));
        }

        public Usuario BuscarUsuarioPorNome(string nomeUsuario)
        {
            return _dbContext.Usuarios.FirstOrDefault(x => string.Equals(x.Nome, nomeUsuario));
        }
    }
}
