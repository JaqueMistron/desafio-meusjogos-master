using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeusJogos.Models
{
    public class UsuarioViewModel
    {
        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(50, ErrorMessage = "Número de caracteres inválido")]
        public string Nome { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public virtual string Senha { get; set; }        
    }
}