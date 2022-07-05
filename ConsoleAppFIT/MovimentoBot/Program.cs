using System;

namespace MovimentoBot
{
    class Program
    {
        static void Main(string[] args)
        {
            int xInicial;
            int yInicial;

            int xFinal;
            int yFinal;

            bool OBotConsegueChegar;

            Console.WriteLine("Informe o valor inicial de x: ");
            xInicial = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Informe o valor inicial de y: ");
            yInicial = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Informe o valor final de x: ");
            xFinal = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe o valor final de y: ");
            yFinal = Convert.ToInt32(Console.ReadLine());

            OBotConsegueChegar = Movimentacao(xInicial, xFinal, yInicial, yFinal);

            if (OBotConsegueChegar)
            {
                Console.WriteLine("O bot consegue chegar ao destino.");
            }
            else
            {
                Console.WriteLine("O bot NÃO consegue chegar ao destino.");
            }

        }

        public static bool Movimentacao(int xInicial, int yInicial, int xFinal, int yFinal)
        {
            if (xFinal < xInicial) return false;
            if (yFinal < yInicial) return false;

            var mdcInicial = mdc(xInicial, yInicial);
            var mdcFinal = mdc(xFinal, yInicial);

            return mdcInicial == mdcFinal;

        }


        // algoritimo de euclides
        static int mdc(int x, int y)
        {
            if (x == y)
                return x;

            if (x > y) return mdc(x - y, y);

            return mdc(x, y - x);
        }
    }
}
