using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProgramasRazor.Pages
{
    public class Programa1Model : PageModel
    {
        [BindProperty]
        public float peso { get; set; }

        [BindProperty]
        public float altura { get; set; }

        public float imc { get; private set; }

        public string clasificacion { get; private set; }

        public void OnPost()
        {
            if (altura > 0)
            {

                imc = peso / (altura * altura);
                clasificacion = ClasificarIMC(imc);
            }

            ModelState.Clear();
        }

        private string ClasificarIMC(float imc)
        {
            if (imc < 18)
                return "Peso Bajo";
            else if (imc >= 18 && imc < 25)
                return "Peso Normal";
            else if (imc >= 25 && imc < 27)
                return "Sobrepeso";
            else if (imc >= 27 && imc < 30)
                return "Obesidad grado I";
            else if (imc >= 30 && imc < 40)
                return "Obesidad grado II";
            else
                return "Obesidad grado III";
        }

    }
}
