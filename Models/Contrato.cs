using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Contrato
    {
        [DisplayName("Contrato")]
        public int CodContrato { get; set; }
        [DisplayName("Futbolista")]
        public string CodDNIoNIE { get; set; }
        [DisplayName("Equipo")]
        public int CodEquipo { get; set; }
        [DisplayName("Fecha de inicio")]
        public DateTime FechaInicio { get; set; }
        [DisplayName("Fecha de fin")]
        public DateTime FechaFin { get; set; }
        [DisplayName("Precio de rescisión")]
        public int PrecioRecision { get; set; }
    }
}
