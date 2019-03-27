using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proceso
{
    public class Pago
    {

        public DateTime FechaPago { get; set; }
        public String FormaDePagoP { get; set; }
        public String MonedaP { get; set; }
        public Decimal Monto { get; set; }

        public Pago()
        {
            documentosRelacionados = new List<DoctoRelacionado>();
        }

        public List<DoctoRelacionado> documentosRelacionados { get; set; }


    }
}
