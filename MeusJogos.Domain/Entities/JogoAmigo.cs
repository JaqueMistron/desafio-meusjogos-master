using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusJogos.Domain.Entities
{
    public class JogoAmigo
    {
        public int IdJogoAmigo { get; set; }
        public int IdAmigo { get; set; }
        public Amigo Amigo { get; set; }
        public int IdJogo { get; set; }
        public Jogo Jogo { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime? DataDevolucao { get; set; }
    }
}
