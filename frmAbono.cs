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
using static BLL.ClienteService;
using static BLL.CuentaService;

namespace ProyectoTienda
{
    public partial class frmAbono : Form
    {
        ClienteService clienteServicio = new ClienteService();
        CuentaService cuentaServicio = new CuentaService();
        AbonoService abonoServicio = new AbonoService();
        public frmAbono()
        {
            InitializeComponent();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Consultar()
        {
            frmConsultaAbonos consulta = new frmConsultaAbonos();
            AddOwnedForm(consulta);
            consulta.FormBorderStyle = FormBorderStyle.None;
            consulta.TopLevel = false;
            consulta.Dock = DockStyle.Fill;
            this.Controls.Add(consulta);
            this.Tag = consulta;
            consulta.BringToFront();
            consulta.Show();
        }
        private void ButtonVolver_Click(object sender, EventArgs e) {
            Close();
        }

        private void FrmAbono_Load(object sender, EventArgs e) {

        }

        private void BtnRegistrarAbono_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtValorAbono.Text) == 0)
            {
                MessageBox.Show("El valor del abono no puede ser cero");
            }
            else
            {


                var respuesta = new Respuesta2();
                try
                {
                    respuesta = cuentaServicio.Consultar();
                    IList<Cuenta> listaAuxiliar = respuesta.Cuentas;
                    decimal deuda = 0;
                    char encontro = 'n';
                    foreach (var item in listaAuxiliar)
                    {
                        if (txtIdentificacion.Text == item.IdCliente && item.Estado.Equals("Activa"))
                        {
                            deuda = item.ValorDeuda;
                            encontro = 's';
                        }
                    }
                    if (encontro == 's')
                    {
                        if (Convert.ToDecimal(txtValorAbono.Text) <= deuda)
                        {
                            Abono abono = new Abono();
                            Asignar(abono);
                            var respuesta2 = abonoServicio.Guardar(abono);
                            MessageBox.Show(respuesta2.Mensaje, "Resultado de guardar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("El valor del abono no puede ser mayor que la deuda actual", "Resultado de guardar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        MessageBox.Show("No se encontró el cliente al cual se le quiere realizar la venta", "Resultado de guardar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Resultado de guardar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }
        }
        private void Asignar(Abono abono)
        {
            var respuesta = cuentaServicio.Consultar();
            IList<Cuenta> listaAuxiliar = respuesta.Cuentas;

            abono.Fecha = DateTime.Now.ToShortDateString();
            abono.ValorAbono = Convert.ToDecimal(txtValorAbono.Text);
            abono.IdCliente = txtIdentificacion.Text;
            foreach (var item in listaAuxiliar)
            {
                if (abono.IdCliente == item.IdCliente && item.Estado.Equals("Activa"))
                {
                    abono.CodigoCuenta = item.Codigo;
                }
            }
        }

        private void TxtValorAbono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar))
            {
                if (e.KeyChar != Convert.ToChar(Keys.Back))
                {
                    MessageBox.Show("Caracter inválido");
                    e.Handled = true;
                }
            }
        }
    }
}
