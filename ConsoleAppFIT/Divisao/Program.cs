using System;
using System.Collections.Generic;
using System.Linq;

namespace Divisao
{
    class Program
    {
        static void Main(string[] args)
        {
            int dividendo;
            int divisor;
            (int quociente, int resto) resultadoDivisao;

            Console.WriteLine("Informe um dividendo: ");
            dividendo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe um divisor: ");
            divisor = Convert.ToInt32(Console.ReadLine());

            resultadoDivisao = Divisao(dividendo, divisor);

            Console.WriteLine($"Para a divisão com o dividendo {dividendo} e divisor {divisor} , tem-se o quociente {resultadoDivisao.quociente} e o resto {resultadoDivisao.resto}.");

        }

        public static (int quociente, int resto) Divisao(int dividendo, int divisor)
        {
            float numeroMultiplicado = 0;
            List<int> possiveisQuocientes = new List<int>();

            //quociente = numero que multiplicado pelo meu divisor da igual ou próximo ao dividendo

            while ((numeroMultiplicado * divisor) <= dividendo)
            {
                possiveisQuocientes.Add((int)numeroMultiplicado);
                numeroMultiplicado++;
            }

            var quociente = possiveisQuocientes.Last();
            var resto = definirOResto(quociente, divisor, dividendo);

            return (quociente, resto); 
        }

        private static int definirOResto(int ultimoPossivelQuociente, int divisor, int dividendo)
        {
            int resultado = ultimoPossivelQuociente * divisor;
            return dividendo - resultado;
        }
    }
}
