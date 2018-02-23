using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeusJogos.Models
{
    public class JogoAmigoViewModel
    {
        public int IdJogoAmigo { get; set; }

        [Display(Name = "Amigo")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int IdAmigo { get; set; }

        [Display(Name = "Jogo")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int IdJogo { get; set; }

        public int IdJogoAnterior { get; set; }

        public AmigoViewModel Amigo { get; set; }
        public JogoViewModel Jogo { get; set; }

        [Display(Name = "Data do empréstimo")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida.")]
        public DateTime DataRetirada { get; set; }

        [Display(Name = "Data da devolução")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Data inválida.")]
        public DateTime? DataDevolucao { get; set; }
    }
}