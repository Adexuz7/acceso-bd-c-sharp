using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Liga
    {
        [DisplayName("Liga")]
        public string CodLiga { get; set; }
        [DisplayName("Nombre")]
        public string NomLiga { get; set; }
    }
}
