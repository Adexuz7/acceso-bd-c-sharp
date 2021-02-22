using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Equipo
    {
        public int CodEquipo { get; set; }
        public string NomEquipo { get; set; }
        public string CodLiga { get; set; }
        public string Localidad { get; set; }
        public bool Internacional { get; set; }
    }
}
