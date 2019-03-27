using System;
using System.Collections.Generic;

namespace Proceso
{
    public class ComprobanteXML
    {


        public String tipodeComprobante { get; set; }

        public String metodoDePago { get; set; }

        public double total { get; set; }

        public double subTotal { get; set; }


        public DateTime fechaExpedido { get; set; }

        public String folio { get; set; }


        public String version { get; set; }


        public String rfcEmisor { get; set; }
        public String nombreEmisor { get; set; }


        public String nombreReceptor { get; set; }

        public String rfcReceptor { get; set; }


        public DateTime? fechaTimbrado { get; set; }


        public string UUId { get; set; }

        public String nombreArchivo { get; set; }

        public String ruta { get; set; }


        public ComprobanteXML()
        {
            this.tipodeComprobante = "Ninguno";
            this.metodoDePago = "Ninguno";
            this.total = 0.0;
            this.subTotal = 0.0;
            this.fechaExpedido = DateTime.Now;
            this.folio = "0";
            this.version = "0";
            this.rfcEmisor = String.Empty;
            this.nombreEmisor = String.Empty;
            this.rfcReceptor = String.Empty;
            this.nombreReceptor = String.Empty;
            this.fechaTimbrado = DateTime.Now;
            this.UUId = String.Empty;
            this.nombreArchivo = String.Empty;
            conceptos = new List<Concepto>();
            pagos = new List<Pago>();

        }

        //List of concepts

        public List<Concepto>  conceptos { get; set; }
        public List<Pago> pagos { get; set; }

    }
}
