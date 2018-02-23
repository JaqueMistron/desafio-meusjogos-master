using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusJogos.Domain.Entities
{
    public class Usuario
    {
        public Usuario()
        {
            ListaJogos = new List<Jogo>();
            ListaAmigos = new List<Amigo>();
            ListaJogosEmprestados = new List<JogoAmigo>();
        }
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public virtual bool Valido { get; set; }

        public virtual List<Jogo> ListaJogos { get; set; }
        public virtual List<Amigo> ListaAmigos { get; set; }
        public virtual List<JogoAmigo> ListaJogosEmprestados { get; set; }
    }
}
