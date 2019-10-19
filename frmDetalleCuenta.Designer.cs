namespace ProyectoTienda
{
    partial class frmDetalleCuenta
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.dtgrDetalleFactura = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.dtgrFactura = new System.Windows.Forms.DataGridView();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pan = new System.Windows.Forms.Panel();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.txtEstadoCuenta = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDeuda = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnGrafica = new System.Windows.Forms.Button();
            this.btnPDF = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrDetalleFactura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrFactura)).BeginInit();
            this.pan.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dtgrDetalleFactura);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.dtgrFactura);
            this.panel1.Controls.Add(this.txtEstado);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(23, 158);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 321);
            this.panel1.TabIndex = 28;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(257, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 15);
            this.label6.TabIndex = 21;
            this.label6.Text = "Detalles de factura";
            // 
            // dtgrDetalleFactura
            // 
            this.dtgrDetalleFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrDetalleFactura.Location = new System.Drawing.Point(13, 178);
            this.dtgrDetalleFactura.MultiSelect = false;
            this.dtgrDetalleFactura.Name = "dtgrDetalleFactura";
            this.dtgrDetalleFactura.ReadOnly = true;
            this.dtgrDetalleFactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgrDetalleFactura.Size = new System.Drawing.Size(625, 132);
            this.dtgrDetalleFactura.TabIndex = 20;
            this.dtgrDetalleFactura.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgrDetalleFactura_CellDoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(168, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(335, 15);
            this.label7.TabIndex = 19;
            this.label7.Text = "Haga doble clic sobre una fila de esta tabla para ver detalles";
            // 
            // dtgrFactura
            // 
            this.dtgrFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrFactura.Location = new System.Drawing.Point(13, 18);
            this.dtgrFactura.MultiSelect = false;
            this.dtgrFactura.Name = "dtgrFactura";
            this.dtgrFactura.ReadOnly = true;
            this.dtgrFactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgrFactura.Size = new System.Drawing.Size(625, 128);
            this.dtgrFactura.TabIndex = 18;
            this.dtgrFactura.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgrFactura_CellDoubleClick);
            // 
            // txtEstado
            // 
            this.txtEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstado.Location = new System.Drawing.Point(275, 53);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(192, 23);
            this.txtEstado.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(170, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Estado cuenta";
            // 
            // pan
            // 
            this.pan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pan.Controls.Add(this.txtFecha);
            this.pan.Controls.Add(this.txtEstadoCuenta);
            this.pan.Controls.Add(this.label9);
            this.pan.Controls.Add(this.label5);
            this.pan.Controls.Add(this.txtApellido);
            this.pan.Controls.Add(this.label8);
            this.pan.Controls.Add(this.txtDeuda);
            this.pan.Controls.Add(this.label4);
            this.pan.Controls.Add(this.txtNombre);
            this.pan.Controls.Add(this.label2);
            this.pan.Controls.Add(this.txtIdentificacion);
            this.pan.Controls.Add(this.label1);
            this.pan.Location = new System.Drawing.Point(23, 12);
            this.pan.Name = "pan";
            this.pan.Size = new System.Drawing.Size(659, 140);
            this.pan.TabIndex = 29;
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.Location = new System.Drawing.Point(436, 100);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(186, 23);
            this.txtFecha.TabIndex = 26;
            // 
            // txtEstadoCuenta
            // 
            this.txtEstadoCuenta.Enabled = false;
            this.txtEstadoCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstadoCuenta.Location = new System.Drawing.Point(436, 58);
            this.txtEstadoCuenta.Name = "txtEstadoCuenta";
            this.txtEstadoCuenta.Size = new System.Drawing.Size(186, 23);
            this.txtEstadoCuenta.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(331, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 17);
            this.label9.TabIndex = 24;
            this.label9.Text = "Estado cuenta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(325, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "Fecha creación";
            // 
            // txtApellido
            // 
            this.txtApellido.Enabled = false;
            this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.Location = new System.Drawing.Point(112, 100);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(192, 23);
            this.txtApellido.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "Primer apellido";
            // 
            // txtDeuda
            // 
            this.txtDeuda.Enabled = false;
            this.txtDeuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeuda.Location = new System.Drawing.Point(436, 13);
            this.txtDeuda.Name = "txtDeuda";
            this.txtDeuda.Size = new System.Drawing.Size(186, 23);
            this.txtDeuda.TabIndex = 21;
            this.txtDeuda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmDetalleCuenta_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(345, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Valor deuda";
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(112, 58);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(192, 23);
            this.txtNombre.TabIndex = 17;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNombre_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Nombre";
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.Enabled = false;
            this.txtIdentificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentificacion.Location = new System.Drawing.Point(112, 13);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(192, 23);
            this.txtIdentificacion.TabIndex = 15;
            this.txtIdentificacion.TextChanged += new System.EventHandler(this.TxtIdentificacion_TextChanged);
            this.txtIdentificacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmDetalleCuenta_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Identificación";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btnEnviar);
            this.panel3.Controls.Add(this.btnGrafica);
            this.panel3.Controls.Add(this.btnPDF);
            this.panel3.Location = new System.Drawing.Point(690, 61);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(154, 348);
            this.panel3.TabIndex = 30;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel3_Paint);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Image = global::ProyectoTienda.Properties.Resources.mensaje_con_sobre_cerrado;
            this.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviar.Location = new System.Drawing.Point(20, 222);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(111, 45);
            this.btnEnviar.TabIndex = 31;
            this.btnEnviar.Text = "enviar correo";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.BtnEnviar_Click_1);
            // 
            // btnGrafica
            // 
            this.btnGrafica.Image = global::ProyectoTienda.Properties.Resources.investigacion;
            this.btnGrafica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrafica.Location = new System.Drawing.Point(20, 153);
            this.btnGrafica.Name = "btnGrafica";
            this.btnGrafica.Size = new System.Drawing.Size(111, 45);
            this.btnGrafica.TabIndex = 30;
            this.btnGrafica.Text = "Graficar ";
            this.btnGrafica.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrafica.UseVisualStyleBackColor = true;
            this.btnGrafica.Click += new System.EventHandler(this.BtnGrafica_Click_1);
            // 
            // btnPDF
            // 
            this.btnPDF.Image = global::ProyectoTienda.Properties.Resources.pdf_simbolo_de_formato_de_archivo1;
            this.btnPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPDF.Location = new System.Drawing.Point(20, 77);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(111, 45);
            this.btnPDF.TabIndex = 29;
            this.btnPDF.Text = "Generar pdf";
            this.btnPDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPDF.UseVisualStyleBackColor = true;
            this.btnPDF.Click += new System.EventHandler(this.BtnPDF_Click);
            // 
            // frmDetalleCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(854, 491);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pan);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDetalleCuenta";
            this.Text = "Formulario de detalles de compras";
            this.Load += new System.EventHandler(this.FrmDetalleCompra_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrDetalleFactura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrFactura)).EndInit();
            this.pan.ResumeLayout(false);
            this.pan.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dtgrDetalleFactura;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dtgrFactura;
        private System.Windows.Forms.Panel pan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDeuda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnGrafica;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.TextBox txtEstadoCuenta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label8;
    }
}