using System;

namespace Proceso {
   public class ComprobanteXML {




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



      public ComprobanteXML () {
         this.tipodeComprobante = "Ninguno";
         this.metodoDePago = "Ninguno";
         this.total = 0.0;
         this.subTotal = 0.0;
         this.fechaExpedido = DateTime.Now;
         this.folio = "0";
         this.version = "0";
         this.rfcEmisor = "";
         this.nombreEmisor = "";
         this.rfcReceptor = "";
         this.nombreReceptor = "";
         this.fechaTimbrado = DateTime.Now;
         this.UUId = "";
         this.nombreArchivo = "";
         }

      }
   }
