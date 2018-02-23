using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MeusJogos.Util
{
    public static class RecursosUtil
    {
        public static string RemoverFormatacao(string textoFormatado)
        {
            if (string.IsNullOrEmpty(textoFormatado))
                return string.Empty;

            return textoFormatado.Replace("(", "").Replace(")", "").Replace("-", "").Replace(".", "").Replace("/", "").Replace(" ", "");
        }

        public static string AdicionarMascaraTelefone(this string texto)
        {
            StringBuilder stb = new StringBuilder();
            if (!String.IsNullOrEmpty(texto) && texto.Length > 0)
            {
                for (int i = 0; i < texto.Length; i++)
                {
                    if (i == 0)
                        stb.Append("(");

                    if (i == 2)
                        stb.Append(") ");

                    if (i == 7 && texto.Length == 11)//Celular
                        stb.Append("-");

                    if (i == 6 && texto.Length == 10)//Telefone
                        stb.Append("-");

                    stb.Append(texto[i]);
                }
            }
            return stb.ToString();
        }
    }
}