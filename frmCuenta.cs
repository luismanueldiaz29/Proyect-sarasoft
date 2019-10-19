using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BLL;
using static BLL.CuentaService;
using static BLL.ClienteService;

namespace ProyectoTienda
{
    public partial class frmCuenta : Form
    {
        CuentaService cuentaServicio = new CuentaService();
        ClienteService clienteServicio = new ClienteService();
        public frmCuenta()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void BtnVerDetalles_Click(object sender, EventArgs e)
        {
            VerDetalles();
        }
        private void VerDetalles()
        {
            if (dtgrCuentas.SelectedRows.Count > 0)
            {
                Cuenta cuenta = new Cuenta();
                var respuesta = new Respuesta2();
                respuesta = cuentaServicio.Consultar();
                int codigoCuenta = Convert.ToInt32(this.dtgrCuentas.CurrentRow.Cells["codigo"].Value);
                foreach (var item in respuesta.Cuentas)
                {
                    if (item.Codigo == codigoCuenta)
                    {
                        cuenta = item;
                    }
                }
                Cliente cliente = new Cliente();
                var respuesta2 = new Respuesta();
                respuesta2 = clienteServicio.Consultar();
                string idCliente = Convert.ToString(this.dtgrCuentas.CurrentRow.Cells["idCliente"].Value);
                foreach (var item in respuesta2.Clientes)
                {
                    if (item.IdCliente == idCliente)
                    {
                        cliente = item;
                    }
                }
                frmDetalleCuenta detalleCompra = new frmDetalleCuenta(cuenta, cliente);
                AddOwnedForm(detalleCompra);
                detalleCompra.FormBorderStyle = FormBorderStyle.None;
                detalleCompra.TopLevel = false;
                detalleCompra.Dock = DockStyle.Fill;
                this.Controls.Add(detalleCompra);
                this.Tag = detalleCompra;
                detalleCompra.BringToFront();
                detalleCompra.Show();
            }
            else
            {
                MessageBox.Show("Escoja la cuenta de la cual quiere ver detalles");
            }
        }

        private void ButtonVolver_Click(object sender, EventArgs e) {
            Close();
        }

        private void FrmDetalle_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            var respuesta = new Respuesta2();
            respuesta = cuentaServicio.Consultar();
            if (!respuesta.IsError)
            {
                dtgrCuentas.DataSource = null;
                dtgrCuentas.DataSource = respuesta.Cuentas;
                dtgrCuentas.Refresh();
            }
            else
            {
                MessageBox.Show(respuesta.Mensaje, respuesta.Mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        

        private void BtnCrearCuenta_Click(object sender, EventArgs e) {
            frmClientes frClientes = new frmClientes();
            AddOwnedForm(frClientes);
            frClientes.FormBorderStyle = FormBorderStyle.None;
            frClientes.TopLevel = false;
            frClientes.Dock = DockStyle.Fill;
            this.Controls.Add(frClientes);
            this.Tag = frClientes;
            frClientes.BringToFront();
            frClientes.Show();
        }

        private void FrmDetalle_KeyPress(object sender, KeyPressEventArgs e) {
            if (!Char.IsNumber(e.KeyChar)) {
                if (e.KeyChar != Convert.ToChar(Keys.Back)) {
                    MessageBox.Show("Caracter invalido");
                    e.Handled = true;
                }
            }
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e) {
            if (!Char.IsLetter(e.KeyChar)) {
                if (!Char.IsWhiteSpace(e.KeyChar)) {
                    if (e.KeyChar != Convert.ToChar(Keys.Back)) {
                        MessageBox.Show("Caracter invalido");
                        e.Handled = true;
                    }
                }
            }
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                MostrarDatos();
            }
            else
            {
                Buscar(txtBuscar.Text);
            }
        }
        private void Buscar(string idCliente)
        {
            var respuesta = new Respuesta2();
            respuesta = cuentaServicio.Buscar(idCliente);
            if (!respuesta.IsError)
            {
                dtgrCuentas.DataSource = null;
                dtgrCuentas.DataSource = respuesta.Cuentas;
                dtgrCuentas.Refresh();
            }
            else
            {
                MessageBox.Show(respuesta.Mensaje, respuesta.Mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            VerAbonos();
        }
        private void VerAbonos()
        {
            if (dtgrCuentas.SelectedRows.Count > 0)
            {
                Cuenta cuenta = new Cuenta();
                var respuesta = new Respuesta2();
                respuesta = cuentaServicio.Consultar();
                int codigoCuenta = Convert.ToInt32(this.dtgrCuentas.CurrentRow.Cells["codigo"].Value);
                foreach (var item in respuesta.Cuentas)
                {
                    if (item.Codigo == codigoCuenta)
                    {
                        cuenta = item;
                    }
                }
                Cliente cliente = new Cliente();
                var respuesta2 = new Respuesta();
                respuesta2 = clienteServicio.Consultar();
                string idCliente = Convert.ToString(this.dtgrCuentas.CurrentRow.Cells["idCliente"].Value);
                foreach (var item in respuesta2.Clientes)
                {
                    if (item.IdCliente == idCliente)
                    {
                        cliente = item;
                    }
                }
                frmConsultaAbonos abonos = new frmConsultaAbonos(cuenta, cliente);
                AddOwnedForm(abonos);
                abonos.FormBorderStyle = FormBorderStyle.None;
                abonos.TopLevel = false;
                abonos.Dock = DockStyle.Fill;
                this.Controls.Add(abonos);
                this.Tag = abonos;
                abonos.BringToFront();
                abonos.Show();
            }
            else
            {
                MessageBox.Show("Escoja la cuenta de la cual quiere ver detalles");
            }
        }

        private void BtnGrafica_Click(object sender, EventArgs e)
        {
            frmEstadisticas grafica = new frmEstadisticas();
            grafica.Show();
        }
    }
}
