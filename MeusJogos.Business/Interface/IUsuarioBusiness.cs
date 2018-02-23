using MeusJogos.Domain.Entities;

namespace MeusJogos.Business.Interface
{
    public interface IUsuarioBusiness
    {
        bool ValidarUsuario(Usuario usuario);
        void Salvar(Usuario usuario);
        bool VerificarUsuarioExistente(string nomeUsuario);
        Usuario BuscarUsuarioPorNome(string nomeUsuario);
    }
}
