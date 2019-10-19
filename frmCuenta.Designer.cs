namespace ProyectoTienda
{
    partial class frmCuenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCuenta));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAbonos = new System.Windows.Forms.Button();
            this.btnCrearCuenta = new System.Windows.Forms.Button();
            this.btnVerDetalles = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtgrCuentas = new System.Windows.Forms.DataGridView();
            this.btnGrafica = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrCuentas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnGrafica);
            this.panel2.Controls.Add(this.btnAbonos);
            this.panel2.Controls.Add(this.btnCrearCuenta);
            this.panel2.Controls.Add(this.btnVerDetalles);
            this.panel2.Location = new System.Drawing.Point(627, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 375);
            this.panel2.TabIndex = 19;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel2_Paint);
            // 
            // btnAbonos
            // 
            this.btnAbonos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbonos.Image = ((System.Drawing.Image)(resources.GetObject("btnAbonos.Image")));
            this.btnAbonos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbonos.Location = new System.Drawing.Point(24, 131);
            this.btnAbonos.Name = "btnAbonos";
            this.btnAbonos.Size = new System.Drawing.Size(149, 45);
            this.btnAbonos.TabIndex = 33;
            this.btnAbonos.Text = "Ver abonos";
            this.btnAbonos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAbonos.UseVisualStyleBackColor = true;
            this.btnAbonos.Click += new System.EventHandler(this.BtnConsultar_Click);
            // 
            // btnCrearCuenta
            // 
            this.btnCrearCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearCuenta.Image = ((System.Drawing.Image)(resources.GetObject("btnCrearCuenta.Image")));
            this.btnCrearCuenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrearCuenta.Location = new System.Drawing.Point(24, 200);
            this.btnCrearCuenta.Name = "btnCrearCuenta";
            this.btnCrearCuenta.Size = new System.Drawing.Size(149, 45);
            this.btnCrearCuenta.TabIndex = 16;
            this.btnCrearCuenta.Text = "Crear cuenta";
            this.btnCrearCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCrearCuenta.UseVisualStyleBackColor = true;
            this.btnCrearCuenta.Click += new System.EventHandler(this.BtnCrearCuenta_Click);
            // 
            // btnVerDetalles
            // 
            this.btnVerDetalles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerDetalles.Image = ((System.Drawing.Image)(resources.GetObject("btnVerDetalles.Image")));
            this.btnVerDetalles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerDetalles.Location = new System.Drawing.Point(23, 60);
            this.btnVerDetalles.Name = "btnVerDetalles";
            this.btnVerDetalles.Size = new System.Drawing.Size(149, 45);
            this.btnVerDetalles.TabIndex = 17;
            this.btnVerDetalles.Text = "Detalles cuenta";
            this.btnVerDetalles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerDetalles.UseVisualStyleBackColor = true;
            this.btnVerDetalles.Click += new System.EventHandler(this.BtnVerDetalles_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.txtBuscar);
            this.panel3.Controls.Add(this.lblBuscar);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.dtgrCuentas);
            this.panel3.Location = new System.Drawing.Point(31, 63);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(564, 375);
            this.panel3.TabIndex = 20;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(216, 29);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(152, 23);
            this.txtBuscar.TabIndex = 44;
            this.txtBuscar.TextChanged += new System.EventHandler(this.TxtBuscar_TextChanged);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.Location = new System.Drawing.Point(47, 32);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(163, 17);
            this.lblBuscar.TabIndex = 43;
            this.lblBuscar.Text = "Buscar por identificación";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(201, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Lista de cuentas";
            // 
            // dtgrCuentas
            // 
            this.dtgrCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrCuentas.Location = new System.Drawing.Point(13, 106);
            this.dtgrCuentas.MultiSelect = false;
            this.dtgrCuentas.Name = "dtgrCuentas";
            this.dtgrCuentas.ReadOnly = true;
            this.dtgrCuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgrCuentas.Size = new System.Drawing.Size(533, 228);
            this.dtgrCuentas.TabIndex = 16;
            // 
            // btnGrafica
            // 
            this.btnGrafica.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrafica.Image = global::ProyectoTienda.Properties.Resources.investigacion;
            this.btnGrafica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrafica.Location = new System.Drawing.Point(23, 266);
            this.btnGrafica.Name = "btnGrafica";
            this.btnGrafica.Size = new System.Drawing.Size(149, 45);
            this.btnGrafica.TabIndex = 34;
            this.btnGrafica.Text = "Estadísticas";
            this.btnGrafica.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrafica.UseVisualStyleBackColor = true;
            this.btnGrafica.Click += new System.EventHandler(this.BtnGrafica_Click);
            // 
            // frmCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(854, 491);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCuenta";
            this.Text = "Detalles de cliente";
            this.Load += new System.EventHandler(this.FrmDetalle_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmDetalle_KeyPress);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrCuentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCrearCuenta;
        private System.Windows.Forms.Button btnVerDetalles;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dtgrCuentas;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Button btnAbonos;
        private System.Windows.Forms.Button btnGrafica;
    }
}