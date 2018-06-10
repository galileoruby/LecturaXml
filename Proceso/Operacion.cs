using System;
using System.Collections.Generic;
using System.Linq;
using OfficeOpenXml;
using System.IO;
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



        public List<ComprobanteXML> ArchivosXmlaProcesarObtener(String sCarpeta)
        {


            facturasGrid = new List<ComprobanteXML>();


            extraccionXML = new List<string>();
            FileInfo existencia = null;


            extraccionXML = iterarDirectorio(sCarpeta);

            foreach (String xmlCurrent in extraccionXML)
            {
                ComprobanteXML xmlAgregar = new ComprobanteXML();

                try
                {
                    existencia = new FileInfo(xmlCurrent);

                    xmlAgregar = XMLExtraerInformacion(xmlCurrent);
                }
                catch (Exception e)
                {
                    String error;
                    error = String.Format("{0} Error:{1}", existencia.Name, e.Message);
                    xmlAgregar.nombreEmisor = error;
                }
                facturasGrid.Add(xmlAgregar);
            }


            return facturasGrid;
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

            var XMLBase = XDocument.Load(xml);
            IEnumerable<XElement> nElementos = XMLBase.Document.Root.Elements();



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





            oXml.version = "3.0"; //predeterminada


            if (null != XMLBase.Document.Root.Attribute("version"))
            {
                oXml.version = (String)XMLBase.Document.Root.Attribute("version").Value;
            }

            if (null != XMLBase.Document.Root.Attribute("Version"))
            {
                oXml.version = (String)XMLBase.Document.Root.Attribute("Version").Value;
            }


            //oXml.version = (String)XMLBase.Document.Root.Attribute("version").Value;


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
                    oXml.nombreEmisor = xEmisor.Attributes("nombre").FirstOrDefault().Value;
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
                    oXml.metodoDePago = XMLBase.Document.Root.Attribute("MetodoPago").Value;

                    oXml.rfcEmisor = xEmisor.Attributes("Rfc").FirstOrDefault().Value;
                    oXml.nombreEmisor = xEmisor.Attributes("Nombre").FirstOrDefault().Value;
                    oXml.rfcReceptor = xReceptor.Attributes("Rfc").FirstOrDefault().Value;

                    oXml.nombreReceptor = "";
                    if (null != xReceptor.Attributes("Nombre").FirstOrDefault())
                    {
                        oXml.nombreReceptor = xReceptor.Attributes("Nombre").FirstOrDefault().Value;
                    }


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


                    foreach (ComprobanteXML nRow in origen)
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
                        hojaNueva.Cells[contador, 13].Value = nRow.nombreArchivo;


                        contador = contador + 1;

                    }

                    for (int a = 1; a < 15; a++)
                    {
                        hojaNueva.Column(a).AutoFit();
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