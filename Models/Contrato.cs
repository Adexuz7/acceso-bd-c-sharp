using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Contrato
    {
        public int CodContrato { get; set; }
        public string CodDNIoNIE { get; set; }
        public int CodEquipo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int PrecioRecision { get; set; }
    }
}
