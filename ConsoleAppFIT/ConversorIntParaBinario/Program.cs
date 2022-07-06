using System;

namespace ConversorIntParaBinario
{
    class Program
    {
        static void Main(string[] args)
        {
            int numero;            
            string binario;

            Console.WriteLine("Informe um Número Inteiro: ");
            numero = Convert.ToInt32(Console.ReadLine());

            binario = Conversor(numero);

            Console.WriteLine($"O valor em binário para este número é {binario}.");
        }

        public static string Conversor(int numero)
        {            
            int resto;
            string binario = string.Empty;

            while (numero > 0)
            {
                resto = numero % 2;
                numero /= 2;
                binario = resto.ToString() + binario;
            }

            return binario;
        }
    }
}
