using System;
using System.Collections.Generic;

namespace ConsoleAppFIT
{
    class Program
    {
        static void Main(string[] args)
        {
            int numero;
            bool numeroEhPrimo;

            Console.WriteLine("Informe um número: ");
            numero = Convert.ToInt32(Console.ReadLine());

            numeroEhPrimo = DefinirSeONumeroEhPrimo(numero);

            if (numeroEhPrimo)
            {
                Console.WriteLine($"O número {numero} é Primo. Número de iterações necessárias: {NumeroIteracoes}.");
            }
            else
            {
                Console.WriteLine($"O número {numero} não é Primo. Número de iterações necessárias: {NumeroIteracoes}.");
            }

        }

        // O número para ser Primo deve possuir apenas dois divisores
        // Para o número ser primo ele tem de ser divisível por 1 e ele mesmo.            
        // Para ser primo ele tem de ser maior que 1.

        public static int NumeroIteracoes = 0;

        public static bool DefinirSeONumeroEhPrimo(int numero)
        {
            if (numero <= 1) return false;

            List<int> divisores = ObterDivisores(numero);

            return divisores.Count == 2 && DefinirSeOsDivisoresSaoONumeroEUm(divisores, numero);
        }

        private static List<int> ObterDivisores(int numero)
        {
            List<int> divisores = new List<int>();

            for (int i = 1; i <= numero; i++)
            {
                if (numero % i == 0) divisores.Add(i);
                NumeroIteracoes ++;
            }

            return divisores;
        }

        private static bool DefinirSeOsDivisoresSaoONumeroEUm(List<int> listaDeDivisores, int numero)
        {
            return listaDeDivisores.Contains(numero) && listaDeDivisores.Contains(1);
        }



    }
}
