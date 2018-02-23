using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeusJogos.Models
{
    public class JogoViewModel
    {
        public int IdJogo { get; set; }

        [Display(Name = "Título do jogo")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(80, ErrorMessage = "Número de caracteres inválido.")]
        public string Titulo { get; set; }

        [Display(Name = "Versão do jogo")]
        [MaxLength(20, ErrorMessage = "Número de caracteres inválido.")]
        public string Versao { get; set; }

        [Display(Name = "Data que adquiriu o jogo")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida.")]
        public DateTime DataAquisicao { get; set; }

        public ICollection<JogoAmigoViewModel> ListaJogosEmprestados { get; set; }

        public List<JogoViewModel> ListaJogosDisponiveis { get; set; }
    }
}