using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

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
        public List<double> resultadosIntermedios { get; private set; } = new List<double>();

        public void OnPost()
        {
            resultado = CalcularExpresion(a, b, x, y, n);
        }

        // M�todo para calcular una expresi�n binomial dada
        private double CalcularExpresion(double a, double b, double x, double y, int n)
        {
            double sum = 0;

            for (int k = 0; k <= n; k++)
            {
                double binomialCoefficient = Factorial(n) / (Factorial(k) * Factorial(n - k));
                double term = binomialCoefficient * Math.Pow(a * x, n - k) * Math.Pow(b * y, k);
                sum += term;
                resultadosIntermedios.Add(term);
            }

            return sum;
        }

        // M�todo para calcular el factorial de un n�mero dado
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
