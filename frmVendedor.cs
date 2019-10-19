using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entity;
using static BLL.VendedorService;

namespace ProyectoTienda {
    public partial class frmVendedor : Form {
        VendedorService vendedorServicio = new VendedorService();

        public frmVendedor() {
            InitializeComponent();
        }

        private void TextBox3_TextChanged(object sender, EventArgs e) {

        }

        private void Label3_Click(object sender, EventArgs e) {

        }

        private void Label2_Click(object sender, EventArgs e) {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e) {

        }

        private void FrmEmpleado_Load(object sender, EventArgs e) {
            MostrarDatos();
        }

        private void ButtonContratar_Click(object sender, EventArgs e) {
            
        }

        private void FrmVendedor_KeyPress(object sender, KeyPressEventArgs e) {

        }

        private void TxtIdentificacion_KeyPress(object sender, KeyPressEventArgs e) {
            if (!Char.IsNumber(e.KeyChar)) {
                if (e.KeyChar != Convert.ToChar(Keys.Back)) {
                    MessageBox.Show("Caracter invalido");
                    e.Handled = true;
                }
            }
        }

        private void TxtNombre1_KeyPress(object sender, KeyPressEventArgs e) {
            if (!Char.IsLetter(e.KeyChar)) {
                if (!Char.IsWhiteSpace(e.KeyChar)) {
                    if (e.KeyChar != Convert.ToChar(Keys.Back)) {
                        MessageBox.Show("Caracter invalido");
                        e.Handled = true;
                    }
                }
            }
        }

        private void ComboBox1_KeyPress(object sender, KeyPressEventArgs e) {
           
        }

        private void TxtCorreo_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsWhiteSpace(e.KeyChar)) {
                MessageBox.Show("Caracter invalido");
                e.Handled = true;
            }
        }

        private void PanelContratar_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Asignar(Vendedor vendedor)
        {
            vendedor.IdVendedor = txtIdentificacion.Text;
            vendedor.Nombre1 = txtNombre1.Text;
            vendedor.Nombre2 = txtNombre2.Text;
            vendedor.Apellido1 = txtApellido1.Text;
            vendedor.Apellido2 = txtApellido2.Text;
            vendedor.Cargo = cmbCargo.Text;
            vendedor.Telefono1 = txtTelefono1.Text;
            vendedor.Telefono2 = txtTelefono2.Text;
            vendedor.Direccion = txtDirecion.Text;
            vendedor.Contraseña = txtContraseña.Text;
        }
        private void Limpiar()
        {
            txtIdentificacion.Text = string.Empty;
            txtNombre1.Text = string.Empty;
            txtNombre2.Text = string.Empty;
            txtApellido1.Text = string.Empty;
            txtApellido2.Text = string.Empty;
            cmbCargo.Text = string.Empty;
            txtTelefono1.Text = string.Empty;
            txtTelefono2.Text = string.Empty;
            txtDirecion.Text = string.Empty;
            txtContraseña.Text = string.Empty;
        }

        private void ButtonGuardar_Click(object sender, EventArgs e)
        {
            var respuesta = new Respuesta();
            try
            {
                Vendedor vendedor = new Vendedor();
                Asignar(vendedor);
                respuesta = vendedorServicio.Guardar(vendedor);
                MessageBox.Show(respuesta.Mensaje, "Resultado de guardar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                Limpiar();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Verifique los datos digitados " + ex.Message, "Resultado de guardar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Vendedor vendedor = new Vendedor();
                Asignar(vendedor);
                Respuesta mensaje = new Respuesta();
                mensaje = vendedorServicio.Modificar(vendedor);
                MessageBox.Show(mensaje.Mensaje);
                Limpiar();
                MostrarDatos();
            }
            else
            {
                MessageBox.Show("No se permiten campos vacios");
            }
        }
        private void MostrarDatos()
        {
            var respuesta = new Respuesta();
            respuesta = vendedorServicio.Consultar();
            if (!respuesta.IsError)
            {
                dtgrVendedor.DataSource = null;

                dtgrVendedor.DataSource = respuesta.Vendedores;
                dtgrVendedor.Refresh();
            }
            else
            {
                MessageBox.Show(respuesta.Mensaje, respuesta.Mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private bool Validar()
        {
            if (txtIdentificacion.Text == "" || txtNombre1.Text == "" || txtApellido1.Text == "" || txtApellido2.Text == "" || txtContraseña.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void DtgrVendedor_Click(object sender, EventArgs e)
        {
            this.txtIdentificacion.Text = Convert.ToString(this.dtgrVendedor.CurrentRow.Cells["Idvendedor"].Value);
            this.txtNombre1.Text = Convert.ToString(this.dtgrVendedor.CurrentRow.Cells["Nombre1"].Value);
            this.txtNombre2.Text = Convert.ToString(this.dtgrVendedor.CurrentRow.Cells["Nombre2"].Value);
            this.txtApellido1.Text = Convert.ToString(this.dtgrVendedor.CurrentRow.Cells["Apellido1"].Value);
            this.txtApellido2.Text = Convert.ToString(this.dtgrVendedor.CurrentRow.Cells["Apellido2"].Value);
            this.cmbCargo.Text = Convert.ToString(this.dtgrVendedor.CurrentRow.Cells["Cargo"].Value);
            this.txtTelefono1.Text = Convert.ToString(this.dtgrVendedor.CurrentRow.Cells["Telefono1"].Value);
            this.txtTelefono2.Text = Convert.ToString(this.dtgrVendedor.CurrentRow.Cells["Telefono2"].Value);
            this.txtDirecion.Text = Convert.ToString(this.dtgrVendedor.CurrentRow.Cells["Direccion"].Value);
            this.txtContraseña.Text = Convert.ToString(this.dtgrVendedor.CurrentRow.Cells["Contraseña"].Value);

        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }
    }
}
