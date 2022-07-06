using GPS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS.Testes
{
    public class MockCenario1
    {
        public List<ParametrosGPS> GerarListaMock()
        {
            var lista = new List<ParametrosGPS>();

            List<string> listaTempoRota = new List<string>(){
            "z a 1",
            "z b 2",
            "a c 2",
            "b c 1"
            };

            lista.Add(new ParametrosGPS
            {
                NomeCidades = "z a b c",
                partidaDestino = "z c",
                QuantidadeCidade = 4,
                QuantidadeEstradas = 4,
                listaTempoRota = listaTempoRota

            });


            lista.Add(new ParametrosGPS
            {
                NomeCidades = "z a b c",
                partidaDestino = "z a",
                QuantidadeCidade = 4,
                QuantidadeEstradas = 4,
                listaTempoRota = listaTempoRota

            });


            lista.Add(new ParametrosGPS
            {
                NomeCidades = "z a b c",
                partidaDestino = "z b",
                QuantidadeCidade = 4,
                QuantidadeEstradas = 4,
                listaTempoRota = listaTempoRota

            });

            return lista;
        }
    }
}
