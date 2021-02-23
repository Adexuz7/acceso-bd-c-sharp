using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Equipo
    {
        [DisplayName("Equipo")]
        public int CodEquipo { get; set; }
        [DisplayName("Nombre")]
        public string NomEquipo { get; set; }
        [DisplayName("Liga")]
        public string CodLiga { get; set; }
        public string Localidad { get; set; }
        public bool Internacional { get; set; }
    }
}
