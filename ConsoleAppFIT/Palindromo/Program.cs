using System;

namespace Palindromo
{
    class Program
    {
        static void Main(string[] args)
        {
            bool stringEhPalindromo;
            string input;

            Console.WriteLine("Digite uma frase/palavra para o código verificar se é um palindromo: ");
            input = Console.ReadLine();

            stringEhPalindromo = DefinirSeEhPalindromo(input);

            if (stringEhPalindromo)
            {
                Console.WriteLine("É um palindromo!");
            }
            else
            {
                Console.WriteLine("Não é um palindromo!");
            }

        }

        public static bool DefinirSeEhPalindromo(string input)
        {

            var textoTratado = input.ToLower();
            textoTratado = RemoverEspacosEmBranco(textoTratado);            
            
            char[] arr = textoTratado.ToCharArray();

            Array.Reverse(arr);

            string temp = new string(arr);
                        
            return textoTratado == temp;
        }

        public static string RemoverEspacosEmBranco(string input)
        {            
            var listaInput = input.ToCharArray();            
            char[] novaString = Array.FindAll(listaInput, NaoEhEspacoVazio);
                                               
            return new string(new string(novaString));
        }

        private static bool NaoEhEspacoVazio(char n)
        {
            return !Char.IsWhiteSpace(n);
        }
    }
}
