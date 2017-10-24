namespace lecturaFacturas {
   partial class frmDesplegarInformacion {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose (bool disposing) {
         if (disposing && (components != null)) {
            components.Dispose();
            }
         base.Dispose(disposing);
         }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent () {
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDesplegarInformacion));
         this.gbx1 = new System.Windows.Forms.GroupBox();
         this.lblArchivo = new System.Windows.Forms.Label();
         this.txtRutaExcel = new System.Windows.Forms.TextBox();
         this.lblEstado = new System.Windows.Forms.Label();
         this.btnExportar = new System.Windows.Forms.Button();
         this.dgvFacturas = new System.Windows.Forms.DataGridView();
         this.rfcEmisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.version = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.metodoDePago = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.nombreEmisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.rfcReceptor = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.nombreReceptor = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.tipodeComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.subTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.fechaExpedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.fechaTimbrado = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.UUId = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.svdExcel = new System.Windows.Forms.SaveFileDialog();
         this.gbx1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
         this.SuspendLayout();
         // 
         // gbx1
         // 
         this.gbx1.Controls.Add(this.lblArchivo);
         this.gbx1.Controls.Add(this.txtRutaExcel);
         this.gbx1.Controls.Add(this.lblEstado);
         this.gbx1.Controls.Add(this.btnExportar);
         this.gbx1.Controls.Add(this.dgvFacturas);
         this.gbx1.Location = new System.Drawing.Point(13, 13);
         this.gbx1.Name = "gbx1";
         this.gbx1.Size = new System.Drawing.Size(1119, 391);
         this.gbx1.TabIndex = 0;
         this.gbx1.TabStop = false;
         this.gbx1.Text = "Información Recolectada";
         // 
         // lblArchivo
         // 
         this.lblArchivo.AutoSize = true;
         this.lblArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblArchivo.Location = new System.Drawing.Point(21, 361);
         this.lblArchivo.Name = "lblArchivo";
         this.lblArchivo.Size = new System.Drawing.Size(103, 13);
         this.lblArchivo.TabIndex = 4;
         this.lblArchivo.Text = "Ruta de Archivo:";
         // 
         // txtRutaExcel
         // 
         this.txtRutaExcel.BackColor = System.Drawing.SystemColors.Control;
         this.txtRutaExcel.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.txtRutaExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txtRutaExcel.Location = new System.Drawing.Point(114, 361);
         this.txtRutaExcel.Name = "txtRutaExcel";
         this.txtRutaExcel.Size = new System.Drawing.Size(629, 13);
         this.txtRutaExcel.TabIndex = 3;
         // 
         // lblEstado
         // 
         this.lblEstado.AutoSize = true;
         this.lblEstado.Location = new System.Drawing.Point(18, 342);
         this.lblEstado.Name = "lblEstado";
         this.lblEstado.Size = new System.Drawing.Size(35, 13);
         this.lblEstado.TabIndex = 2;
         this.lblEstado.Text = "label1";
         // 
         // btnExportar
         // 
         this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
         this.btnExportar.Location = new System.Drawing.Point(962, 351);
         this.btnExportar.Name = "btnExportar";
         this.btnExportar.Size = new System.Drawing.Size(119, 23);
         this.btnExportar.TabIndex = 1;
         this.btnExportar.Text = "Exportar";
         this.btnExportar.UseVisualStyleBackColor = true;
         this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
         // 
         // dgvFacturas
         // 
         this.dgvFacturas.AllowDrop = true;
         this.dgvFacturas.AllowUserToAddRows = false;
         dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
         this.dgvFacturas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
         this.dgvFacturas.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
         this.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dgvFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rfcEmisor,
            this.version,
            this.metodoDePago,
            this.nombreEmisor,
            this.rfcReceptor,
            this.nombreReceptor,
            this.tipodeComprobante,
            this.total,
            this.subTotal,
            this.fechaExpedido,
            this.fechaTimbrado,
            this.folio,
            this.UUId});
         this.dgvFacturas.Location = new System.Drawing.Point(6, 19);
         this.dgvFacturas.Name = "dgvFacturas";
         this.dgvFacturas.ReadOnly = true;
         this.dgvFacturas.Size = new System.Drawing.Size(1075, 311);
         this.dgvFacturas.TabIndex = 0;
         this.dgvFacturas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
         // 
         // rfcEmisor
         // 
         this.rfcEmisor.DataPropertyName = "rfcEmisor";
         this.rfcEmisor.HeaderText = "RFC Emisor";
         this.rfcEmisor.MaxInputLength = 20;
         this.rfcEmisor.Name = "rfcEmisor";
         this.rfcEmisor.ReadOnly = true;
         // 
         // version
         // 
         this.version.DataPropertyName = "version";
         this.version.HeaderText = "Version";
         this.version.Name = "version";
         this.version.ReadOnly = true;
         // 
         // metodoDePago
         // 
         this.metodoDePago.DataPropertyName = "metodoDePago";
         this.metodoDePago.HeaderText = "Metodo de Pago";
         this.metodoDePago.MaxInputLength = 50;
         this.metodoDePago.Name = "metodoDePago";
         this.metodoDePago.ReadOnly = true;
         // 
         // nombreEmisor
         // 
         this.nombreEmisor.DataPropertyName = "nombreEmisor";
         this.nombreEmisor.HeaderText = "Razon Social";
         this.nombreEmisor.MaxInputLength = 200;
         this.nombreEmisor.Name = "nombreEmisor";
         this.nombreEmisor.ReadOnly = true;
         // 
         // rfcReceptor
         // 
         this.rfcReceptor.DataPropertyName = "rfcReceptor";
         this.rfcReceptor.HeaderText = "RFC Receptor";
         this.rfcReceptor.MaxInputLength = 20;
         this.rfcReceptor.Name = "rfcReceptor";
         this.rfcReceptor.ReadOnly = true;
         // 
         // nombreReceptor
         // 
         this.nombreReceptor.DataPropertyName = "nombreReceptor";
         this.nombreReceptor.HeaderText = "Razon Social";
         this.nombreReceptor.MaxInputLength = 200;
         this.nombreReceptor.Name = "nombreReceptor";
         this.nombreReceptor.ReadOnly = true;
         // 
         // tipodeComprobante
         // 
         this.tipodeComprobante.DataPropertyName = "tipodeComprobante";
         this.tipodeComprobante.HeaderText = "Comprobante";
         this.tipodeComprobante.MaxInputLength = 50;
         this.tipodeComprobante.Name = "tipodeComprobante";
         this.tipodeComprobante.ReadOnly = true;
         // 
         // total
         // 
         this.total.DataPropertyName = "total";
         dataGridViewCellStyle2.Format = "C2";
         dataGridViewCellStyle2.NullValue = null;
         this.total.DefaultCellStyle = dataGridViewCellStyle2;
         this.total.HeaderText = "Total";
         this.total.MaxInputLength = 20;
         this.total.Name = "total";
         this.total.ReadOnly = true;
         // 
         // subTotal
         // 
         this.subTotal.DataPropertyName = "subTotal";
         dataGridViewCellStyle3.Format = "C2";
         dataGridViewCellStyle3.NullValue = null;
         this.subTotal.DefaultCellStyle = dataGridViewCellStyle3;
         this.subTotal.HeaderText = "Sub Total";
         this.subTotal.MaxInputLength = 30;
         this.subTotal.Name = "subTotal";
         this.subTotal.ReadOnly = true;
         // 
         // fechaExpedido
         // 
         this.fechaExpedido.DataPropertyName = "fechaExpedido";
         this.fechaExpedido.HeaderText = "Fecha";
         this.fechaExpedido.MaxInputLength = 50;
         this.fechaExpedido.Name = "fechaExpedido";
         this.fechaExpedido.ReadOnly = true;
         // 
         // fechaTimbrado
         // 
         this.fechaTimbrado.DataPropertyName = "fechaTimbrado";
         this.fechaTimbrado.HeaderText = "Fecha Timbrado";
         this.fechaTimbrado.Name = "fechaTimbrado";
         this.fechaTimbrado.ReadOnly = true;
         // 
         // folio
         // 
         this.folio.DataPropertyName = "folio";
         this.folio.HeaderText = "Folio";
         this.folio.MaxInputLength = 20;
         this.folio.Name = "folio";
         this.folio.ReadOnly = true;
         // 
         // UUId
         // 
         this.UUId.DataPropertyName = "UUId";
         this.UUId.HeaderText = "UUID";
         this.UUId.MaxInputLength = 50;
         this.UUId.Name = "UUId";
         this.UUId.ReadOnly = true;
         // 
         // svdExcel
         // 
         this.svdExcel.AddExtension = false;
         this.svdExcel.DefaultExt = "xlsx";
         this.svdExcel.Filter = "Microsoft Excel (*.xlsx)|*.xlsx";
         // 
         // frmDesplegarInformacion
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1138, 416);
         this.Controls.Add(this.gbx1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Name = "frmDesplegarInformacion";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "frmDesplegarInformacion";
         this.Load += new System.EventHandler(this.frmDesplegarInformacion_Load);
         this.gbx1.ResumeLayout(false);
         this.gbx1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
         this.ResumeLayout(false);

         }

      #endregion
      private System.Windows.Forms.GroupBox gbx1;
      private System.Windows.Forms.DataGridView dgvFacturas;
      private System.Windows.Forms.Button btnExportar;
      private System.Windows.Forms.Label lblEstado;
      private System.Windows.Forms.TextBox txtRutaExcel;
      private System.Windows.Forms.SaveFileDialog svdExcel;
      private System.Windows.Forms.Label lblArchivo;
      private System.Windows.Forms.DataGridViewTextBoxColumn rfcEmisor;
      private System.Windows.Forms.DataGridViewTextBoxColumn version;
      private System.Windows.Forms.DataGridViewTextBoxColumn metodoDePago;
      private System.Windows.Forms.DataGridViewTextBoxColumn nombreEmisor;
      private System.Windows.Forms.DataGridViewTextBoxColumn rfcReceptor;
      private System.Windows.Forms.DataGridViewTextBoxColumn nombreReceptor;
      private System.Windows.Forms.DataGridViewTextBoxColumn tipodeComprobante;
      private System.Windows.Forms.DataGridViewTextBoxColumn total;
      private System.Windows.Forms.DataGridViewTextBoxColumn subTotal;
      private System.Windows.Forms.DataGridViewTextBoxColumn fechaExpedido;
      private System.Windows.Forms.DataGridViewTextBoxColumn fechaTimbrado;
      private System.Windows.Forms.DataGridViewTextBoxColumn folio;
      private System.Windows.Forms.DataGridViewTextBoxColumn UUId;
      }
   }