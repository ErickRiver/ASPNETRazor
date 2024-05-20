using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProgramasRazor.Pages
{
    public class Programa3Model : PageModel
    {
        [BindProperty]
        public double a { get; set; }

        [BindProperty]
        public double b { get; set; }

        [BindProperty]
        public double x { get; set; }

        [BindProperty]
        public double y { get; set; }

        [BindProperty]
        public int n { get; set; }

        public double? resultado { get; private set; }

        public void OnPost()
        {
            resultado = CalcularExpresion(a, b, x, y, n);
        }

        private double CalcularExpresion(double a, double b, double x, double y, int n)
        {
            double sum = 0;
            for (int k = 0; k <= n; k++)
            {
                double binomialCoefficient = Factorial(n) / (Factorial(k) * Factorial(n - k));
                sum += binomialCoefficient * Math.Pow(a * x, n - k) * Math.Pow(b * y, k);
            }
            return sum;
        }

        private double Factorial(int numero)
        {
            if (numero == 0)
                return 1;

            double resul = 1;
            for (int i = 1; i <= numero; i++)
            {
                resul *= i;
            }
            return resul;
        }
    }
}
