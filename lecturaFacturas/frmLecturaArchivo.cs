using System.Windows.Forms;
using Proceso;
using System.Collections.Generic;

namespace lecturaFacturas
{
    public partial class frmLecturaArchivo : Form
    {

        Operacion oExtraer;
        Respuesta oRespuesta;
        List<ComprobanteXML> facturasGrid;

        public frmLecturaArchivo()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            this.Text = "Facturas";
            lblEstado.Text = "Listo";
        }

        private void btnExtraer_Click(object sender, System.EventArgs e)
        {


            if (string.IsNullOrEmpty(txtRutaCarpeta.Text))
            {
                return;
            }

            oRespuesta = new Respuesta();
            oExtraer = new Operacion();
            facturasGrid = new List<ComprobanteXML>();
            oRespuesta = oExtraer.EstablecerCarpeta(txtRutaCarpeta.Text);


            lblEstado.Text = oRespuesta.Mensaje;

            facturasGrid = oExtraer.ArchivosXmlaProcesarObtener(txtRutaCarpeta.Text, ref lblEstatus);


            frmDesplegarInformacion of = new frmDesplegarInformacion();

            of.CargarFacturas(facturasGrid);


            of.Show();


        }

        private void btnExplorar_Click(object sender, System.EventArgs e)
        {

            fBrow = new FolderBrowserDialog();


            if (fBrow.ShowDialog() == DialogResult.OK)
            {
                txtRutaCarpeta.Text = fBrow.SelectedPath;
            }


        }
    }
}


