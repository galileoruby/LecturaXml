using Proceso;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace lecturaFacturas
{
    public partial class frmDesplegarInformacion : Form
    {
        public frmDesplegarInformacion()
        {
            InitializeComponent();
        }


        Operacion nObjetoExportar;

        private void frmDesplegarInformacion_Load(object sender, EventArgs e)
        {
            this.Text = "Desplegado de información.";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        internal void CargarFacturas(List<ComprobanteXML> source)
        {

            dgvFacturas.AutoGenerateColumns = false;

            dgvFacturas.DataSource = source;
            lblEstado.Text = String.Format("{0} Registros encontrados.", source.Count);






        }

        private void btnExportar_Click(object sender, EventArgs e)
        {


            String sArchivo = String.Empty;



            using (SaveFileDialog fbRutaExcel = new SaveFileDialog())
            {


                if (svdExcel.ShowDialog() == DialogResult.OK)
                {

                    sArchivo = svdExcel.FileName;
                    txtRutaExcel.Text = sArchivo;
                }

            }


            if (String.IsNullOrEmpty(sArchivo))
            {
                lblEstado.Text = "No se ha exportado nada.";
                return;
            }

            nObjetoExportar = new Operacion();
            List<ComprobanteXML> exportar = new List<ComprobanteXML>();

            foreach (DataGridViewRow nRow in dgvFacturas.Rows)
            {

                ComprobanteXML nExportar = new ComprobanteXML();

                if (null != (nRow.Cells["rfcEmisor"].Value))
                    nExportar.rfcEmisor = nRow.Cells["rfcEmisor"].Value.ToString();

                if (null != (nRow.Cells["nombreEmisor"].Value))
                    nExportar.nombreEmisor = nRow.Cells["nombreEmisor"].Value.ToString();

                if (null != (nRow.Cells["rfcReceptor"].Value))
                    nExportar.rfcReceptor = nRow.Cells["rfcReceptor"].Value.ToString();

                if (null != (nRow.Cells["nombreReceptor"].Value))
                    nExportar.nombreReceptor = nRow.Cells["nombreReceptor"].Value.ToString();

                if (null != (nRow.Cells["folio"].Value))
                    nExportar.folio = nRow.Cells["folio"].Value.ToString();

                if (null != (nRow.Cells["tipodeComprobante"].Value))
                    nExportar.tipodeComprobante = nRow.Cells["tipodeComprobante"].Value.ToString();


                if (null != (nRow.Cells["metodoDePago"].Value))
                    nExportar.metodoDePago = nRow.Cells["metodoDePago"].Value.ToString();

                if (null != (nRow.Cells["total"].Value))
                    nExportar.total = double.Parse(nRow.Cells["total"].Value.ToString().Replace("$", ""));

                if (null != (nRow.Cells["subTotal"].Value))
                    nExportar.subTotal = double.Parse(nRow.Cells["subTotal"].Value.ToString().Replace("$", ""));

                if (null != (nRow.Cells["fechaExpedido"].Value))
                    nExportar.fechaExpedido = DateTime.Parse(nRow.Cells["fechaExpedido"].Value.ToString());


                if (null != (nRow.Cells["version"].Value))
                    nExportar.version = nRow.Cells["version"].Value.ToString();

                if (null != (nRow.Cells["fechaTimbrado"].Value))
                    nExportar.fechaTimbrado = DateTime.Parse(nRow.Cells["fechaTimbrado"].Value.ToString());


                if (null != (nRow.Cells["UUId"].Value))
                    nExportar.UUId = nRow.Cells["UUId"].Value.ToString();

                if (null != (nRow.Cells["nombreArchivo"].Value))
                    nExportar.nombreArchivo = nRow.Cells["nombreArchivo"].Value.ToString();


                exportar.Add(nExportar);



            }

            try
            {
                nObjetoExportar.EscribirExcel(exportar, sArchivo);
                lblArchivo.Text = String.Format("{0} se ha guardado correctamente.", sArchivo);
                MessageBox.Show(String.Format("{0} se ha guardado correctamente.", sArchivo));

            }
            catch (Exception e2)
            {
                lblEstado.Text = "Error al exportar: " + e2.Message;
            }


        }
    }
}
