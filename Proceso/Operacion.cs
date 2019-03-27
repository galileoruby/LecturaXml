using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Proceso
{
    public class Operacion
    {



        private String sCarpeta;
        List<String> extraccionXML;
        public List<ComprobanteXML> facturasGrid;

        Respuesta res;

        public Respuesta EstablecerCarpeta(String carpeta)
        {

            //validar que exista carpeta, archivos

            res = new Respuesta();



            if (String.IsNullOrEmpty(carpeta))
            {
                res.Mensaje = "No se ha cargado una carpeta valida.";
                return res;
            }



            sCarpeta = carpeta;
            res.Mensaje = String.Format("Cargando archivos de carpeta: {0} ", carpeta);


            return res;


        }


        public List<String> rfcIncluir
        {
            get
            {
                List<String> rfcIncluir = new List<String>();

                rfcIncluir.Add("LSO8412216D2");

                rfcIncluir.Add("SHO141201RQ6");

                rfcIncluir.Add("IPH160113G9A");

                rfcIncluir.Add("SCO150516JX8");

                rfcIncluir.Add("ESO150516QG2");

                rfcIncluir.Add("IPH160113G9A");

                rfcIncluir.Add("CIS1412019M6");
                return rfcIncluir;
            }
        }


        public List<ComprobanteXML> ArchivosXmlaProcesarObtener(String sCarpeta, ref System.Windows.Forms.Label estatus)
        {


            facturasGrid = new List<ComprobanteXML>();


            extraccionXML = new List<string>();
            FileInfo existencia = null;






            String[] subdirectoryEntries = Directory.GetDirectories(sCarpeta);


            if (0 != subdirectoryEntries.Length)
            {

                foreach (String primario in subdirectoryEntries)
                {
                    extraccionXML = iterarDirectorio(primario);

                    estatus.Text = String.Format("iterando ruta '{0}'.", primario);
                    estatus.Refresh();

                    foreach (String xmlCurrent in extraccionXML)
                    {
                        ComprobanteXML xmlAgregar = new ComprobanteXML();

                        try
                        {
                            existencia = new FileInfo(xmlCurrent);

                            xmlAgregar = XMLExtraerInformacion(xmlCurrent);
                            xmlAgregar.ruta = sCarpeta;
                        }



                        catch (Exception e)
                        {
                            String error;
                            error = String.Format("{0} Error:{1}", existencia.Name, e.Message);
                            xmlAgregar.nombreEmisor = error;
                        }

                        if (rfcIncluir.Contains(xmlAgregar.rfcReceptor))
                        facturasGrid.Add(xmlAgregar);
                    }


                }
            }

            if (0 == subdirectoryEntries.Length)
            {

                extraccionXML = iterarDirectorio(sCarpeta);

                estatus.Text = String.Format("iterando ruta '{0}'.", extraccionXML);
                estatus.Refresh();

                foreach (String xmlCurrent in extraccionXML)
                {
                    ComprobanteXML xmlAgregar = new ComprobanteXML();

                    try
                    {
                        existencia = new FileInfo(xmlCurrent);

                        xmlAgregar = XMLExtraerInformacion(xmlCurrent);
                        xmlAgregar.ruta = sCarpeta;


                        //estatus.Text = String.Format("iterando ruta '{0}'.", primario);
                        //estatus.Refresh();
                    }



                    catch (Exception e)
                    {
                        String error;
                        error = String.Format("{0} Error:{1}", existencia.Name, e.Message);
                        xmlAgregar.nombreEmisor = error;
                    }
                    if (rfcIncluir.Contains(xmlAgregar.rfcReceptor))
                        facturasGrid.Add(xmlAgregar);
                }


            }

            return facturasGrid;
             
        }




        public List<ComprobanteXML> SeleccionarRFC(List<ComprobanteXML> origen)
        {

         
            return origen.Where(ab => rfcIncluir.Contains(ab.rfcReceptor)).OrderBy(ab => ab.rfcReceptor).ToList();

        }



        public List<String> iterarDirectorio(String sDir)
        {
            List<String> files = new List<string>();

            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {

                    //if (0 != String.Compare(, "XML")) {
                    FileInfo existencia = new FileInfo(f);

                    if (0 == String.Compare(existencia.Extension, ".xml"))
                        files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {

                    FileInfo existencia = new FileInfo(d);

                    if (0 == String.Compare(existencia.Extension, ".xml"))
                        files.AddRange(iterarDirectorio(d));
                }
            }
            catch (System.Exception excpt)
            {
                throw excpt;
            }

            return files;

        }

        public ComprobanteXML XMLExtraerInformacion(String xml)
        {


            FileInfo existenciaArchivo = new FileInfo(xml);
            ComprobanteXML oXml = new ComprobanteXML();

            XDocument XMLBase = XDocument.Load(xml);
            IEnumerable<XElement> nElementos = XMLBase.Document.Root.Elements();


            XNamespace sat = "http://www.sat.gob.mx/cfd/3 Conceptos";


            oXml.nombreArchivo = existenciaArchivo.Name;

            IEnumerable<XElement> xEmisor = (from emisor in nElementos
                                             where emisor.Name.LocalName == "Emisor"
                                             select emisor
                        ).ToList();


            IEnumerable<XElement> xReceptor = (from emisor in nElementos
                                               where emisor.Name.LocalName == "Receptor"
                                               select emisor
                        ).ToList();


            var xComplemento = (from emisor in nElementos
                                where emisor.Name.LocalName == "Complemento"
                                select emisor
                        ).Descendants();





            var xConceptos = (from emisor in nElementos
                              where emisor.Name.LocalName == "Conceptos"
                              select emisor
                      ).Descendants();



            XElement xElementConcepto = null;
            XElement xElementoPagos = null;


            foreach (XElement okas in nElementos)
            {
                //xElementConcepto = okas;
                if (okas.Name.LocalName == "Conceptos")
                {
                    xElementConcepto = okas;
                    break;
                }


            }



            foreach (XElement okas in nElementos)
            {

                if (okas.Name.LocalName == "Complemento")
                {

                    foreach (XElement nPago in okas.Elements())
                    {

                        if (nPago.Name.LocalName == "Pagos")
                        {

                            foreach (XElement docRelacionado in nPago.Elements())
                            {
                                if (docRelacionado.Name.LocalName == "Pago")
                                    xElementoPagos = docRelacionado;
                                break;
                            }
                        }
                    }
                }

            }







            oXml.version = "3.0"; //predeterminada


            if (null != XMLBase.Document.Root.Attribute("version"))
            {
                oXml.version = (String)XMLBase.Document.Root.Attribute("version").Value;
            }

            if (null != XMLBase.Document.Root.Attribute("Version"))
            {
                oXml.version = (String)XMLBase.Document.Root.Attribute("Version").Value;
            }



            switch (oXml.version)
            {


                case "3.2":


                    oXml.tipodeComprobante = (String)XMLBase.Document.Root.Attribute("tipoDeComprobante").Value;
                    oXml.total = Double.Parse(XMLBase.Document.Root.Attribute("total").Value);
                    oXml.subTotal = Double.Parse(XMLBase.Document.Root.Attribute("subTotal").Value);
                    oXml.fechaExpedido = DateTime.Parse(XMLBase.Document.Root.Attribute("fecha").Value);

                    oXml.folio = "";
                    if (null != XMLBase.Document.Root.Attribute("folio"))
                    {
                        if (!String.IsNullOrEmpty(XMLBase.Document.Root.Attribute("folio").Value))
                        {

                            oXml.folio = XMLBase.Document.Root.Attribute("folio").Value;
                        }
                    }
                    oXml.metodoDePago = XMLBase.Document.Root.Attribute("metodoDePago").Value;

                    oXml.rfcEmisor = xEmisor.Attributes("rfc").FirstOrDefault().Value;


                    if (null != xEmisor.Attributes("nombre").FirstOrDefault())
                    {
                        oXml.nombreEmisor = xEmisor.Attributes("nombre").FirstOrDefault().Value;
                    }

                    oXml.rfcReceptor = xReceptor.Attributes("rfc").FirstOrDefault().Value;

                    oXml.nombreReceptor = "";
                    if (null != xReceptor.Attributes("nombre").FirstOrDefault())
                    {
                        oXml.nombreReceptor = xReceptor.Attributes("nombre").FirstOrDefault().Value;
                    }

                    break;

                case "3.3":



                    oXml.tipodeComprobante = (String)XMLBase.Document.Root.Attribute("TipoDeComprobante").Value;
                    oXml.total = Double.Parse(XMLBase.Document.Root.Attribute("Total").Value);
                    oXml.subTotal = Double.Parse(XMLBase.Document.Root.Attribute("SubTotal").Value);
                    oXml.fechaExpedido = DateTime.Parse(XMLBase.Document.Root.Attribute("Fecha").Value);

                    oXml.folio = "";
                    if (null != XMLBase.Document.Root.Attribute("Folio"))
                    {
                        if (!String.IsNullOrEmpty(XMLBase.Document.Root.Attribute("Folio").Value))
                        {

                            oXml.folio = XMLBase.Document.Root.Attribute("Folio").Value;
                        }
                    }


                    oXml.rfcEmisor = xEmisor.Attributes("Rfc").FirstOrDefault().Value;
                    if (null != xEmisor.Attributes("Nombre").FirstOrDefault())
                    {
                        oXml.nombreEmisor = xEmisor.Attributes("Nombre").FirstOrDefault().Value;
                    }
                    oXml.rfcReceptor = xReceptor.Attributes("Rfc").FirstOrDefault().Value;

                    oXml.nombreReceptor = String.Empty;
                    if (null != xReceptor.Attributes("Nombre").FirstOrDefault())
                    {
                        oXml.nombreReceptor = xReceptor.Attributes("Nombre").FirstOrDefault().Value;
                    }



                    if (null != XMLBase.Document.Root.Attribute("MetodoPago"))
                    {
                        oXml.metodoDePago = XMLBase.Document.Root.Attribute("MetodoPago").Value;
                    }







                    if (null != xElementConcepto)
                    {

                        foreach (var currentConcepto in xElementConcepto.Elements())
                        {


                            Concepto nuevoConcepto = new Concepto();

                            if (null != currentConcepto.Attribute("Cantidad"))
                            {
                                int cant = 0;
                                int.TryParse(currentConcepto.Attribute("Cantidad").Value, out cant);
                                nuevoConcepto.Cantidad = cant;
                            }

                            if (null != currentConcepto.Attribute("ClaveProdServ"))
                            {
                                nuevoConcepto.ClaveProdServ = currentConcepto.Attribute("ClaveProdServ").Value;
                            }

                            if (null != currentConcepto.Attribute("ClaveUnidad"))
                            {
                                nuevoConcepto.ClaveUnidad = currentConcepto.Attribute("ClaveUnidad").Value;
                            }



                            if (null != currentConcepto.Attribute("Descripcion"))
                            {
                                nuevoConcepto.Descripcion = currentConcepto.Attribute("Descripcion").Value;
                            }


                            if (null != currentConcepto.Attribute("Importe"))
                            {
                                Decimal imp = 0;
                                Decimal.TryParse(currentConcepto.Attribute("Importe").Value, out imp);
                                nuevoConcepto.Importe = imp;
                            }


                            if (null != currentConcepto.Attribute("Unidad"))
                            {
                                nuevoConcepto.Unidad = currentConcepto.Attribute("Unidad").Value;
                            }


                            if (null != currentConcepto.Attribute("ValorUnitario"))
                            {
                                Decimal valUnit = 0;
                                Decimal.TryParse(currentConcepto.Attribute("ValorUnitario").Value, out valUnit);
                                nuevoConcepto.ValorUnitario = valUnit;
                            }







                            oXml.conceptos.Add(nuevoConcepto);
                        }

                    }

                    if ("P" == oXml.tipodeComprobante && null != xElementoPagos)
                    {

                        CultureInfo culture = new CultureInfo("es-MX");

                        Pago nuevoPago = new Pago();

                        if (null != xElementoPagos.Attribute("FechaPago"))
                        {
                            DateTime _fp;
                            DateTime.TryParse(xElementoPagos.Attribute("FechaPago").Value, out _fp);
                            nuevoPago.FechaPago = _fp;
                        }

                        if (null != xElementoPagos.Attribute("FormaDePagoP"))
                        {
                            nuevoPago.FormaDePagoP = xElementoPagos.Attribute("FormaDePagoP").Value;
                        }

                        if (null != xElementoPagos.Attribute("MonedaP"))
                        {
                            nuevoPago.MonedaP = xElementoPagos.Attribute("MonedaP").Value;
                        }


                        if (null != xElementoPagos.Attribute("Monto"))
                        {
                            Decimal mo = 0;
                            Decimal.TryParse(xElementoPagos.Attribute("Monto").Value, out mo);
                            nuevoPago.Monto = mo;
                        }

                        foreach (XElement currentPago in xElementoPagos.Elements())
                        {

                            DoctoRelacionado nuevoDocto = new DoctoRelacionado();

                            if (null != currentPago.Attribute("IdDocumento"))
                            {
                                Guid id = Guid.Empty;
                                Guid.TryParse(currentPago.Attribute("IdDocumento").Value, out id);
                                nuevoDocto.IdDocumento = id;
                            }

                            if (null != currentPago.Attribute("Serie"))
                            {
                                nuevoDocto.Serie = currentPago.Attribute("Serie").Value;
                            }


                            if (null != currentPago.Attribute("Folio"))
                            {
                                nuevoDocto.Folio = currentPago.Attribute("Folio").Value;
                            }


                            if (null != currentPago.Attribute("MonedaDR"))
                            {
                                nuevoDocto.MonedaDR = currentPago.Attribute("MonedaDR").Value;
                            }

                            if (null != currentPago.Attribute("MetodoDePagoDR"))
                            {
                                nuevoDocto.MetodoDePagoDR = currentPago.Attribute("MetodoDePagoDR").Value;
                            }


                            if (null != currentPago.Attribute("NumParcialidad"))
                            {
                                int nd = 0;
                                int.TryParse(currentPago.Attribute("NumParcialidad").Value, out nd);
                                nuevoDocto.NumParcialidad = nd;
                            }

                            if (null != currentPago.Attribute("ImpSaldoAnt"))
                            {
                                Decimal ist = 0;
                                Decimal.TryParse(currentPago.Attribute("ImpSaldoAnt").Value, out ist);
                                nuevoDocto.ImpSaldoAnt = ist;
                            }



                            if (null != currentPago.Attribute("ImpPagado"))
                            {
                                Decimal imd = 0;

                                Decimal.TryParse(currentPago.Attribute("ImpPagado").Value, out imd);
                                nuevoDocto.ImpPagado = imd;
                            }

                            if (null != currentPago.Attribute("ImpSaldoInsoluto"))
                            {
                                Decimal iso = 0;
                                Decimal.TryParse(currentPago.Attribute("ImpSaldoInsoluto").Value, out iso);
                                nuevoDocto.ImpSaldoInsoluto = iso;
                            }


                            nuevoPago.documentosRelacionados.Add(nuevoDocto);




                        }
                        oXml.pagos.Add(nuevoPago);

                    }





                    //}



                    break;


                default:

                    break;

            }




            DateTime _fechaTimbrado = DateTime.Now;

            DateTime.TryParse(xComplemento.Attributes("FechaTimbrado").FirstOrDefault().Value, out _fechaTimbrado);
            oXml.fechaTimbrado = _fechaTimbrado;
            oXml.UUId = xComplemento.Attributes("UUID").FirstOrDefault().Value.ToString();

            return oXml;

        }




        public void EscribirExcel(List<ComprobanteXML> origen, String rutaArchivo)
        {


            if (!rutaArchivo.EndsWith(".xlsx"))
                rutaArchivo = rutaArchivo + ".xlsx";

            FileInfo guardarExcel = new FileInfo(rutaArchivo);
            if (null == origen)
                return;

            int contador = 2;


            try
            {

                using (var paquete = new ExcelPackage())
                {

                    //ingreso egreso traslado
                    if (origen.Where(ab => !ab.tipodeComprobante.Contains("P")).Any())
                    {
                        ExcelWorksheet hojaNueva = paquete.Workbook.Worksheets.Add("Facturas");

                        //imprimir Encabezados

                        hojaNueva.Cells[1, 1].Value = "RFC Emisor";
                        hojaNueva.Cells[1, 2].Value = "Nombre Emisor";
                        hojaNueva.Cells[1, 3].Value = "RFC Receptor";
                        hojaNueva.Cells[1, 4].Value = "Nombre Receptor";
                        hojaNueva.Cells[1, 5].Value = "Tipo de Comprobante";
                        hojaNueva.Cells[1, 6].Value = "Método de Pago";
                        hojaNueva.Cells[1, 7].Value = "Folio";
                        hojaNueva.Cells[1, 8].Value = "Version";
                        hojaNueva.Cells[1, 9].Value = "Sub Total";
                        hojaNueva.Cells[1, 10].Value = "Total";
                        hojaNueva.Cells[1, 11].Value = "Fecha Expedido";
                        hojaNueva.Cells[1, 12].Value = "Fecha Timbrado";
                        hojaNueva.Cells[1, 13].Value = "UUID";
                        hojaNueva.Cells[1, 14].Value = "Archivo";

                        hojaNueva.Cells[1, 15].Value = "Numero concepto";
                        hojaNueva.Cells[1, 16].Value = "Cantidad";
                        hojaNueva.Cells[1, 17].Value = "ClaveProdServ";
                        hojaNueva.Cells[1, 18].Value = "Unidad";
                        hojaNueva.Cells[1, 19].Value = "Descripcion";
                        hojaNueva.Cells[1, 20].Value = "Importe";
                        hojaNueva.Cells[1, 21].Value = "Unidad";
                        hojaNueva.Cells[1, 22].Value = "ValorUnitario";
                        hojaNueva.Cells[1, 23].Value = "Ruta";

                        int contadorConceptos = 0;

                        foreach (ComprobanteXML nRow in origen.Where(ab => !ab.tipodeComprobante.Contains("P")))
                        {

                            contadorConceptos = 1;

                            foreach (Concepto nConcepto in nRow.conceptos)
                            {
                                hojaNueva.Cells[contador, 1].Value = nRow.rfcEmisor;
                                hojaNueva.Cells[contador, 2].Value = nRow.nombreEmisor;
                                hojaNueva.Cells[contador, 3].Value = nRow.rfcReceptor;
                                hojaNueva.Cells[contador, 4].Value = nRow.nombreReceptor;
                                hojaNueva.Cells[contador, 5].Value = nRow.tipodeComprobante;
                                hojaNueva.Cells[contador, 6].Value = nRow.metodoDePago;
                                hojaNueva.Cells[contador, 7].Value = nRow.folio;
                                hojaNueva.Cells[contador, 8].Value = nRow.version;

                                //$#,##0.00
                                hojaNueva.Cells[contador, 9].Style.Numberformat.Format = "$#,##0.00";
                                hojaNueva.Cells[contador, 9].Value = nRow.subTotal;

                                hojaNueva.Cells[contador, 10].Style.Numberformat.Format = "$#,##0.00";
                                hojaNueva.Cells[contador, 10].Value = nRow.total;

                                hojaNueva.Cells[contador, 11].Style.Numberformat.Format = "yyyy-mm-dd hh:mm:ss";
                                hojaNueva.Cells[contador, 11].Value = nRow.fechaExpedido;


                                hojaNueva.Cells[contador, 12].Style.Numberformat.Format = "yyyy-mm-dd hh:mm:ss";
                                hojaNueva.Cells[contador, 12].Value = nRow.fechaTimbrado;

                                hojaNueva.Cells[contador, 13].Value = nRow.UUId;
                                hojaNueva.Cells[contador, 14].Value = nRow.nombreArchivo;
                                hojaNueva.Cells[contador, 15].Value = contadorConceptos;
                                hojaNueva.Cells[contador, 16].Value = nConcepto.Cantidad;
                                hojaNueva.Cells[contador, 17].Value = nConcepto.ClaveProdServ;
                                hojaNueva.Cells[contador, 18].Value = nConcepto.Unidad;
                                hojaNueva.Cells[contador, 19].Value = nConcepto.Descripcion;
                                hojaNueva.Cells[contador, 20].Value = nConcepto.Importe;
                                hojaNueva.Cells[contador, 21].Value = nConcepto.Unidad;
                                hojaNueva.Cells[contador, 22].Value = nConcepto.ValorUnitario;
                                hojaNueva.Cells[contador, 23].Value = nRow.ruta;

                                contador = contador + 1;
                                contadorConceptos += 1;

                            }

                        }


                        for (int a = 1; a < 50; a++)
                        {
                            hojaNueva.Column(a).AutoFit();
                        }

                    }



                    if (origen.Where(ab => ab.tipodeComprobante.Contains("P")).Any())
                    {
                        ExcelWorksheet hojaNueva = paquete.Workbook.Worksheets.Add("ComplementodePago");

                        contador = 2;
                        //imprimir Encabezados

                        hojaNueva.Cells[1, 1].Value = "RFC Emisor";
                        hojaNueva.Cells[1, 2].Value = "Nombre Emisor";
                        hojaNueva.Cells[1, 3].Value = "RFC Receptor";
                        hojaNueva.Cells[1, 4].Value = "Nombre Receptor";
                        hojaNueva.Cells[1, 5].Value = "Tipo de Comprobante";
                        hojaNueva.Cells[1, 6].Value = "Método de Pago";
                        hojaNueva.Cells[1, 7].Value = "Folio";
                        hojaNueva.Cells[1, 8].Value = "Version";
                        hojaNueva.Cells[1, 9].Value = "Sub Total";
                        hojaNueva.Cells[1, 10].Value = "Total";
                        hojaNueva.Cells[1, 11].Value = "Fecha Expedido";
                        hojaNueva.Cells[1, 12].Value = "Fecha Timbrado";
                        hojaNueva.Cells[1, 13].Value = "UUID";
                        hojaNueva.Cells[1, 14].Value = "Archivo";


                        hojaNueva.Cells[1, 15].Value = "Numero concepto";

                        hojaNueva.Cells[1, 16].Value = "Fecha Pago";
                        hojaNueva.Cells[1, 17].Value = "FormaDePagoP";
                        hojaNueva.Cells[1, 18].Value = "MonedaP";
                        hojaNueva.Cells[1, 19].Value = "Monto";


                        hojaNueva.Cells[1, 20].Value = "IdDocumento";
                        hojaNueva.Cells[1, 21].Value = "Serie";
                        hojaNueva.Cells[1, 22].Value = "Folio";
                        hojaNueva.Cells[1, 23].Value = "MonedaDR";
                        hojaNueva.Cells[1, 24].Value = "MetodoDePagoDR";
                        hojaNueva.Cells[1, 25].Value = "NumParcialidad";
                        hojaNueva.Cells[1, 26].Value = "ImpSaldoAnt";
                        hojaNueva.Cells[1, 27].Value = "ImpPagado";
                        hojaNueva.Cells[1, 28].Value = "ImpSaldoInsoluto";
                        hojaNueva.Cells[1, 29].Value = "Ruta";


                        int contadorConceptos = 0;

                        foreach (ComprobanteXML nRow in origen.Where(ab => ab.tipodeComprobante.Contains("P")))
                        {

                            contadorConceptos = 1;

                            foreach (Pago nPago in nRow.pagos)
                            {
                                foreach (DoctoRelacionado docRelacionado in nPago.documentosRelacionados)
                                {

                                    hojaNueva.Cells[contador, 1].Value = nRow.rfcEmisor;
                                    hojaNueva.Cells[contador, 2].Value = nRow.nombreEmisor;
                                    hojaNueva.Cells[contador, 3].Value = nRow.rfcReceptor;
                                    hojaNueva.Cells[contador, 4].Value = nRow.nombreReceptor;
                                    hojaNueva.Cells[contador, 5].Value = nRow.tipodeComprobante;
                                    hojaNueva.Cells[contador, 6].Value = nRow.metodoDePago;
                                    hojaNueva.Cells[contador, 7].Value = nRow.folio;
                                    hojaNueva.Cells[contador, 8].Value = nRow.version;

                                    //$#,##0.00
                                    hojaNueva.Cells[contador, 9].Style.Numberformat.Format = "$#,##0.00";
                                    hojaNueva.Cells[contador, 9].Value = nRow.subTotal;

                                    hojaNueva.Cells[contador, 10].Style.Numberformat.Format = "$#,##0.00";
                                    hojaNueva.Cells[contador, 10].Value = nRow.total;

                                    hojaNueva.Cells[contador, 11].Style.Numberformat.Format = "yyyy-mm-dd hh:mm:ss";
                                    hojaNueva.Cells[contador, 11].Value = nRow.fechaExpedido;


                                    hojaNueva.Cells[contador, 12].Style.Numberformat.Format = "yyyy-mm-dd hh:mm:ss";
                                    hojaNueva.Cells[contador, 12].Value = nRow.fechaTimbrado;

                                    hojaNueva.Cells[contador, 13].Value = nRow.UUId;
                                    hojaNueva.Cells[contador, 14].Value = nRow.nombreArchivo;

                                    hojaNueva.Cells[contador, 15].Value = contadorConceptos;

                                    hojaNueva.Cells[contador, 16].Style.Numberformat.Format = "yyyy-mm-dd hh:mm:ss";
                                    hojaNueva.Cells[contador, 16].Value = nPago.FechaPago;

                                    hojaNueva.Cells[contador, 17].Value = nPago.FormaDePagoP;
                                    hojaNueva.Cells[contador, 18].Value = nPago.MonedaP;

                                    hojaNueva.Cells[contador, 19].Style.Numberformat.Format = "$#,##0.00";
                                    hojaNueva.Cells[contador, 19].Value = nPago.Monto;

                                    hojaNueva.Cells[contador, 20].Value = docRelacionado.IdDocumento;
                                    hojaNueva.Cells[contador, 21].Value = docRelacionado.Serie;
                                    hojaNueva.Cells[contador, 22].Value = docRelacionado.Folio;
                                    hojaNueva.Cells[contador, 23].Value = docRelacionado.MonedaDR;
                                    hojaNueva.Cells[contador, 24].Value = docRelacionado.MetodoDePagoDR;
                                    hojaNueva.Cells[contador, 25].Value = docRelacionado.NumParcialidad;


                                    hojaNueva.Cells[contador, 26].Style.Numberformat.Format = "$#,##0.00";
                                    hojaNueva.Cells[contador, 26].Value = docRelacionado.ImpSaldoAnt;

                                    hojaNueva.Cells[contador, 27].Style.Numberformat.Format = "$#,##0.00";
                                    hojaNueva.Cells[contador, 27].Value = docRelacionado.ImpPagado;

                                    hojaNueva.Cells[contador, 28].Style.Numberformat.Format = "$#,##0.00";
                                    hojaNueva.Cells[contador, 28].Value = docRelacionado.ImpSaldoInsoluto;

                                    hojaNueva.Cells[contador, 29].Value = nRow.ruta;


                                    contador = contador + 1;
                                    contadorConceptos += 1;

                                }
                            }



                        }


                        for (int a = 1; a < 50; a++)
                        {
                            hojaNueva.Column(a).AutoFit();
                        }
                    }




                    paquete.SaveAs(guardarExcel);

                }




            }
            catch (Exception e)
            {
                throw new Exception("Error al generar excel,revise configuración.");
            }


        }


    }
} //namespace Proceso