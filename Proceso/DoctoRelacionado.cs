using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proceso
{
    public class DoctoRelacionado

    {

        public Guid IdDocumento { get; set; }
        public String Serie { get; set; }
        public String Folio { get; set; }
        public String MonedaDR { get; set; }
        public String MetodoDePagoDR { get; set; }
        public int NumParcialidad { get; set; }
        public Decimal ImpSaldoAnt { get; set; }
        public Decimal ImpPagado { get; set; }
        public Decimal ImpSaldoInsoluto { get; set; }
    }
}
