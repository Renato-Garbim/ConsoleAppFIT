using GPS.DTO;
using GPS.Testes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GPS
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ambiente de Teste
            var mock = new MockCenario1();

            List<ParametrosGPS> listaParametros = new List<ParametrosGPS>(); // aloca no heap
            listaParametros = mock.GerarListaMock();

            // Para fazer o teste mecanico descomentar as linhas abaixo e comentar a linha de mock, deixando apenas o ListParametros

            //Console.WriteLine($"Informe porfavor o número de testes que gostaria de realizar:");
            //int numeroTestes = int.Parse(Console.ReadLine());

            //int numeroTestes = 3; // um forloop de acordo com o numero de testes

            //Console.WriteLine($"Para cada teste sera requisitado dados diferentes, uma quantidade de cidades, outra de estradas (ambas devem ser números inteiros) o nome das cidades e para cada estrada um tempo de rota.");
            //Console.WriteLine($"Por favor insira o tempo das rotas informando (nome da cidade) 'espaço' (nome da cidade) 'espaco' (tempo do trajeto).");

            //for (var e = 0; e < numeroTestes; e++)
            //{
            //    //int numeroCidades = 4;
            //    //string nomeCidades = "z a b c"; // formato (c1 c2 c3 c4)
            //    //int numeroEstradas = 4; // um forloop para cada estrada aonde recebera o input TempoRota            

            //    Console.WriteLine($"Por favor insira a quantidade de Cidades:");
            //    int numeroCidades = int.Parse(Console.ReadLine());

            //    Console.WriteLine($"Por favor insira a quantidade de Estradas:");
            //    int numeroEstradas = int.Parse(Console.ReadLine());

            //    Console.WriteLine($"Por favor insira o nome das Cidades:");
            //    string nomeCidades = Console.ReadLine();

            //    //string tempoRota; // tempo da rota entre cidades onde o formato do input é ( c1 c2 t )

            //    List<string> listaTempoRota = new List<string>();

            //    for (var r = 0; r < numeroEstradas; r++)
            //    {
            //        Console.WriteLine($"Por favor insira a o tempo da Rota:");

            //        string tempoRota = Console.ReadLine();

            //        listaTempoRota.Add(tempoRota);
            //    }

            //    //List<string> listaTempoRota = new List<string>()
            //    //{
            //    //"z a 1",
            //    //"z b 2",
            //    //"a c 2",
            //    //"b c 1"};


            //    Console.WriteLine($"Por favor insira o ponto de Partida e o Destino:");
            //    //string inicioChegada = "z c"; // cidade de inicio e chegada no formato de (c1 c2)
            //    string inicioChegada = Console.ReadLine();

            //    listaParametros.Add(new ParametrosGPS() { 

            //        NomeCidades = nomeCidades,
            //        partidaDestino = inicioChegada,
            //        QuantidadeCidade = numeroCidades,
            //        QuantidadeEstradas = numeroEstradas,
            //        listaTempoRota = listaTempoRota

            //    });

            //}

            List<int> Resultados = definirMenorTrajeto(listaParametros);

            foreach (var tempo in Resultados)
            {
                Console.WriteLine($"{tempo}");
            }
            
        }

        public static List<int> definirMenorTrajeto(List<ParametrosGPS> parametros)
        {            
            List<int> listaTempoTestes = new List<int>();  // aloca no heap

            foreach (var parametro in parametros)
            {
                Dictionary<string, int> dicionarioRotas = new Dictionary<string, int>(); // aloca no heap
                bool localizadoMenorTrajetoTempo = false;

                string nomeCidadeTratado = RemoverEspacosEmBranco(parametro.NomeCidades);
                List<char> listaCidade = nomeCidadeTratado.ToArray().ToList();

                char cidadeInicial = listaCidade.FirstOrDefault();
                char cidadeFinal = listaCidade.LastOrDefault();
                

                string inicioDestinoTratado = RemoverEspacosEmBranco(parametro.partidaDestino);

                foreach (var elemento in parametro.listaTempoRota)
                {
                    char inicio;
                    char destino;
                    string tempoExtraido;
                    int tempoPercurso;

                    string elementoTratado = RemoverEspacosEmBranco(elemento);
                    char[] array = elementoTratado.ToCharArray();
                    tempoExtraido = array.Where(x => Char.IsNumber(x)).FirstOrDefault().ToString();

                    array = array.Where(x => !Char.IsNumber(x)).Select(x => x).ToArray();

                    inicio = array.FirstOrDefault();
                    destino = array.LastOrDefault();

                    tempoPercurso = int.Parse(tempoExtraido);

                    // trafego intenso = 5 horas de atraso no tempo de saida ( atraso + t )

                    if (DefinirSeCidadeTemTrafegoIntenso(inicio))
                    {
                        tempoPercurso = tempoPercurso + 5;
                    }

                    //Caso a cidade de partida e de destino se encontre diretamente nas Rotas passadas o algoritimo apenas devolve o tempo entre elas.

                    if (inicioDestinoTratado.Equals(new string(array)))
                    {
                        listaTempoTestes.Add(tempoPercurso);
                        localizadoMenorTrajetoTempo = true;
                        break;
                        //return tempoPercurso;
                    }

                    dicionarioRotas.Add($"{inicio}{destino}", tempoPercurso);
                }

                if (localizadoMenorTrajetoTempo) continue;

                // selecionar todas as rotas da cidade inicial para x
                // selecionar todas as rotas que contenham a cidade final
                // selecionar as rotas que não contenham nenhuma das duas

                var rotasCidadeInicial = dicionarioRotas.Where(x => x.Key.Contains(cidadeInicial)).Select(x => x.Key);
                var rotasCidadeFinal = dicionarioRotas.Where(x => x.Key.Contains(cidadeFinal)).Select(x => x.Key);
                var rotasQueNaoContenhamAsCidades = dicionarioRotas.Where(x => !x.Key.Contains(cidadeFinal) && !x.Key.Contains(cidadeInicial)).Select(x => x.Key);
                List<int> listaTempoTrajeto = new List<int>();

                foreach (var rota in rotasCidadeInicial)
                {
                    var tempoRota = dicionarioRotas.Where(x => x.Key == rota).Select(x => x.Value).FirstOrDefault();
                    var cidadeDestino = rota.ToCharArray().Where(x => x != cidadeInicial).FirstOrDefault().ToString();

                    //Não estou utilizando o Any porque ele tinha um BUG nas versões anteriores do core, não consegui localizar se foi corrigido.
                    if (rotasQueNaoContenhamAsCidades.Count() != 0)
                    {
                        tempoRota = tempoRota + dicionarioRotas.Where(x => x.Key == cidadeDestino).Select(x => x.Value).Min();
                    }

                    tempoRota = tempoRota + dicionarioRotas.Where(x => x.Key.Contains(cidadeFinal) && x.Key.Contains(cidadeDestino)).Select(x => x.Value).Min();

                    listaTempoTrajeto.Add(tempoRota);
                }

                listaTempoTestes.Add(listaTempoTrajeto.Min());
            }

            return listaTempoTestes;
        }

        public static bool DefinirSeCidadeTemTrafegoIntenso(char cidade)
        {
            return "aeiou".IndexOf(cidade.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0;
        }

        private static bool NaoEhEspacoVazio(char n)
        {
            return !Char.IsWhiteSpace(n);
        }

        public static string RemoverEspacosEmBranco(string input)
        {
            var listaInput = input.ToCharArray();
            char[] novaString = Array.FindAll(listaInput, NaoEhEspacoVazio);

            return new string(new string(novaString));
        }


    }
}
