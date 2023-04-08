using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEINT_PruebaLinq
{
    internal class Persona
    {
        public String? nombre { get; set; } = null;
        public Int16 edad { get; set; }
        public DateTime fechaIngreso { get; set; }
        public Boolean soltero { get; set; }
    }
}
