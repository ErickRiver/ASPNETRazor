using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProgramasRazor.Pages
{
    public class Programa4Model : PageModel
    {
        public int[] numeros { get; private set; }
        public int suma { get; private set; }
        public double media { get; private set; }
        public List<int> moda { get; private set; }
        public double mediana { get; private set; }

        public void OnPost()
        {
            GenerarArreglo();
            Sumar();
            ObtenerMediaAritmetica();
            ObtenerModa();
            ObtenerMediana();
        }

        private void GenerarArreglo()
        {
            Random random = new Random();
            numeros = new int[20];
            for (int i = 0; i < numeros.Length; i++)
            {
                numeros[i] = random.Next(0, 101);
            }
        }

        private void Sumar()
        {
            suma = numeros.Sum();
        }

        private void ObtenerMediaAritmetica()
        {
            media = numeros.Average();
        }

        private void ObtenerModa()
        {
            var conteoNumeros = numeros.GroupBy(n => n)
                                       .ToDictionary(g => g.Key, g => g.Count());

            int maximoConteo = conteoNumeros.Values.Max();

            moda = conteoNumeros.Where(kv => kv.Value == maximoConteo)
                               .Select(kv => kv.Key)
                               .ToList();
        }

        private void ObtenerMediana()
        {
            var ordenarNumeros = numeros.OrderBy(n => n).ToArray();
            int med = ordenarNumeros.Length / 2;

            if (ordenarNumeros.Length % 2 == 0)
            {
                mediana = (ordenarNumeros[med - 1] + ordenarNumeros[med]) / 2.0;
            }
            else
            {
                mediana = ordenarNumeros[med];
            }
        }
    }
}
