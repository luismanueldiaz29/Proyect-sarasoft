namespace ProyectoTienda
{
    partial class frmAbono
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbono));
            this.txtValorAbono = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegistrarAbono = new System.Windows.Forms.Button();
            this.dtmFechaAbono = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtValorAbono
            // 
            this.txtValorAbono.Location = new System.Drawing.Point(170, 185);
            this.txtValorAbono.Name = "txtValorAbono";
            this.txtValorAbono.Size = new System.Drawing.Size(126, 20);
            this.txtValorAbono.TabIndex = 18;
            this.txtValorAbono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtValorAbono_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(58, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Valor abono";
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.Location = new System.Drawing.Point(170, 92);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(126, 20);
            this.txtIdentificacion.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(96, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Fecha";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Identificación";
            // 
            // btnRegistrarAbono
            // 
            this.btnRegistrarAbono.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarAbono.Image = ((System.Drawing.Image)(resources.GetObject("btnRegistrarAbono.Image")));
            this.btnRegistrarAbono.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRegistrarAbono.Location = new System.Drawing.Point(144, 250);
            this.btnRegistrarAbono.Name = "btnRegistrarAbono";
            this.btnRegistrarAbono.Size = new System.Drawing.Size(88, 74);
            this.btnRegistrarAbono.TabIndex = 19;
            this.btnRegistrarAbono.Text = "Registrar abono";
            this.btnRegistrarAbono.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRegistrarAbono.UseVisualStyleBackColor = true;
            this.btnRegistrarAbono.Click += new System.EventHandler(this.BtnRegistrarAbono_Click);
            // 
            // dtmFechaAbono
            // 
            this.dtmFechaAbono.Enabled = false;
            this.dtmFechaAbono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmFechaAbono.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmFechaAbono.Location = new System.Drawing.Point(170, 138);
            this.dtmFechaAbono.Name = "dtmFechaAbono";
            this.dtmFechaAbono.Size = new System.Drawing.Size(126, 20);
            this.dtmFechaAbono.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(99, -1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "Formulario de abonos";
            // 
            // frmAbono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(370, 365);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtmFechaAbono);
            this.Controls.Add(this.btnRegistrarAbono);
            this.Controls.Add(this.txtValorAbono);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtIdentificacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "frmAbono";
            this.Text = "Formulario de abonos";
            this.Load += new System.EventHandler(this.FrmAbono_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValorAbono;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegistrarAbono;
        private System.Windows.Forms.DateTimePicker dtmFechaAbono;
        private System.Windows.Forms.Label label4;
    }
}