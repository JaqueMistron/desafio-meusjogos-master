using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusJogos.Domain.Entities
{
    public class Jogo
    {
        public Jogo()
        {
            ListaJogosEmprestados = new List<JogoAmigo>();
        }
        public int IdJogo { get; set; }
        public string Titulo { get; set; }
        public string Versao { get; set; }
        public DateTime? DataAquisicao { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public virtual List<JogoAmigo> ListaJogosEmprestados { get; set; }
    }
}
