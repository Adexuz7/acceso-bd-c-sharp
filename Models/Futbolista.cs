using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Futbolista
    {
        [DisplayName("DNI o NIE")]
        public string CodDNIoNIE { get; set; }
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }
    }
}
