using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS.DTO
{
    public class ParametrosGPS
    {
        public int QuantidadeCidade { get; set; }
        public string NomeCidades { get; set; }
        public int QuantidadeEstradas { get; set; }
        public List<string> listaTempoRota { get; set; }
        public string partidaDestino { get; set; }
    }
}
