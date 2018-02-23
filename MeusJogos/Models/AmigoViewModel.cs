using MeusJogos.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MeusJogos.Models
{
    public class AmigoViewModel
    {
        public int IdAmigo { get; set; }
        private string telefone;

        [Display(Name = "Nome do amigo")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(50, ErrorMessage = "Número de caracteres inválido.")]
        public string Nome { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [RegularExpression("^\\([1-9]{2}\\) [2-9][0-9]{3,4}\\-[0-9]{4}$", ErrorMessage = "Telefone em formato inválido.")]
        public string Telefone //{ get; set; }
         {
            get { return RecursosUtil.AdicionarMascaraTelefone(telefone); }

            set { telefone = value; }
        }
        
        public ICollection<JogoAmigoViewModel> ListaJogosEmprestados { get; set; }
    }
}