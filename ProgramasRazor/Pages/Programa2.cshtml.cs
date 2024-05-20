using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace ProgramasRazor.Pages
{
    public class Programa2Model : PageModel
    {
        [BindProperty]
        public string mensaje { get; set; }

        [BindProperty]
        public int desplazamiento { get; set; }

        [BindProperty]
        public string operacion { get; set; }

        public string resultado { get; private set; }

        public void OnPost()
        {
            if (!string.IsNullOrEmpty(mensaje))
            {
                if (operacion == "codificar")
                {
                    resultado = Codificar(mensaje.ToUpper(), desplazamiento);
                }
                else if (operacion == "decodificar")
                {
                    resultado = Decodificar(mensaje.ToUpper(), desplazamiento);
                }
            }
        }

        private string Codificar(string mensaje, int desplazamiento)
        {
            StringBuilder resultado = new StringBuilder();

            foreach (char c in mensaje)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    char encodedChar = (char)((c + desplazamiento - offset) % 26 + offset);
                    resultado.Append(encodedChar);
                }
                else
                {
                    resultado.Append(c);
                }
            }

            return resultado.ToString();
        }

        private string Decodificar(string mensaje, int desplazamiento)
        {
            return Codificar(mensaje, 26 - (desplazamiento % 26));
        }
    }
}
