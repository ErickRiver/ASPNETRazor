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
            // Agrupa los números en 'numeros' y cuenta la cantidad de veces que aparece cada número
            var conteoNumeros = numeros.GroupBy(n => n)
                                       .ToDictionary(g => g.Key, g => g.Count());

            // Encuentra el valor máximo del conteo de números
            int maximoConteo = conteoNumeros.Values.Max();

            // Filtra los números que tienen el conteo máximo y los convierte en una lista
            moda = conteoNumeros.Where(kv => kv.Value == maximoConteo)
                                .Select(kv => kv.Key)
                                .ToList();
        }

        private void ObtenerMediana()
        {
            // Ordena los números en 'numeros' y los convierte en un arreglo
            var ordenarNumeros = numeros.OrderBy(n => n).ToArray();

            // Calcula el índice medio del arreglo
            int med = ordenarNumeros.Length / 2;

            // Si la cantidad de números es par, la mediana es el promedio de los dos números centrales
            if (ordenarNumeros.Length % 2 == 0)
            {
                mediana = (ordenarNumeros[med - 1] + ordenarNumeros[med]) / 2.0;
            }
            // Si la cantidad de números es impar, la mediana es el número central
            else
            {
                mediana = ordenarNumeros[med];
            }
        }
    }
}
