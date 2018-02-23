using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusJogos.Domain.Entities
{
    public class Amigo
    {
        public Amigo()
        {
            ListaJogosEmprestados = new List<JogoAmigo>();
        }

        public int IdAmigo { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public virtual List<JogoAmigo> ListaJogosEmprestados { get; set; }
    }
}
