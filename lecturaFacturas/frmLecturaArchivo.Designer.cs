namespace lecturaFacturas {
    partial class frmLecturaArchivo {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
                {
                components.Dispose();
                }
            base.Dispose(disposing);
            }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLecturaArchivo));
            this.gbx = new System.Windows.Forms.GroupBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnExplorar = new System.Windows.Forms.Button();
            this.txtRutaCarpeta = new System.Windows.Forms.TextBox();
            this.lblRuta = new System.Windows.Forms.Label();
            this.btnExtraer = new System.Windows.Forms.Button();
            this.fBrow = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gbx.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbx
            // 
            this.gbx.Controls.Add(this.lblEstado);
            this.gbx.Controls.Add(this.btnExplorar);
            this.gbx.Controls.Add(this.txtRutaCarpeta);
            this.gbx.Controls.Add(this.lblRuta);
            this.gbx.Controls.Add(this.btnExtraer);
            this.gbx.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbx.Location = new System.Drawing.Point(12, 8);
            this.gbx.Name = "gbx";
            this.gbx.Size = new System.Drawing.Size(611, 232);
            this.gbx.TabIndex = 0;
            this.gbx.TabStop = false;
            this.gbx.Text = "Extraer Facturas";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblEstado.Location = new System.Drawing.Point(7, 249);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(0, 13);
            this.lblEstado.TabIndex = 4;
            // 
            // btnExplorar
            // 
            this.btnExplorar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExplorar.Location = new System.Drawing.Point(521, 83);
            this.btnExplorar.Name = "btnExplorar";
            this.btnExplorar.Size = new System.Drawing.Size(75, 23);
            this.btnExplorar.TabIndex = 3;
            this.btnExplorar.Text = "Explorar";
            this.btnExplorar.UseVisualStyleBackColor = true;
            this.btnExplorar.Click += new System.EventHandler(this.btnExplorar_Click);
            // 
            // txtRutaCarpeta
            // 
            this.txtRutaCarpeta.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtRutaCarpeta.Location = new System.Drawing.Point(61, 40);
            this.txtRutaCarpeta.Name = "txtRutaCarpeta";
            this.txtRutaCarpeta.Size = new System.Drawing.Size(535, 20);
            this.txtRutaCarpeta.TabIndex = 2;
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblRuta.Location = new System.Drawing.Point(7, 43);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(33, 13);
            this.lblRuta.TabIndex = 1;
            this.lblRuta.Text = "Ruta:";
            // 
            // btnExtraer
            // 
            this.btnExtraer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExtraer.Location = new System.Drawing.Point(521, 191);
            this.btnExtraer.Name = "btnExtraer";
            this.btnExtraer.Size = new System.Drawing.Size(75, 23);
            this.btnExtraer.TabIndex = 0;
            this.btnExtraer.Text = "Extraer";
            this.btnExtraer.UseVisualStyleBackColor = true;
            this.btnExtraer.Click += new System.EventHandler(this.btnExtraer_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmLecturaArchivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 247);
            this.Controls.Add(this.gbx);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLecturaArchivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lector XML";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbx.ResumeLayout(false);
            this.gbx.PerformLayout();
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.GroupBox gbx;
        private System.Windows.Forms.Button btnExtraer;
        private System.Windows.Forms.FolderBrowserDialog fBrow;
        private System.Windows.Forms.TextBox txtRutaCarpeta;
        private System.Windows.Forms.Label lblRuta;
        private System.Windows.Forms.Button btnExplorar;
      private System.Windows.Forms.Label lblEstado;
      private System.Windows.Forms.OpenFileDialog openFileDialog1;
      }
    }

