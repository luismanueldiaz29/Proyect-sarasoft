using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InputKey;
using BLL;
using Entity;
using static BLL.AbonoService;

namespace ProyectoTienda
{
    public partial class frmConsultaAbonos : Form
    {
        AbonoService abonoServicio = new AbonoService();
        Cliente cliente = new Cliente();
        Cuenta cuenta = new Cuenta();
        public frmConsultaAbonos()
        {
            InitializeComponent();
        }
        public frmConsultaAbonos(Cuenta cuenta, Cliente cliente)
        {
            InitializeComponent();
            this.cuenta = cuenta;
            this.cliente = cliente;
            MapearCajas();
            MostrarDatos2();
        }
        private void MapearCajas()
        {
            txtIdentificacion.Text = cliente.IdCliente;
            txtNombreCliente.Text = cliente.Nombre1;
            txtApellido.Text = cliente.Apellido1;
            txtDeuda.Text = Convert.ToString(cuenta.ValorDeuda);
            txtEstado.Text = cuenta.Estado;
            txtFecha.Text = cuenta.FechaCreacion;
        }
        private void MostrarDatos2()
        {
            var respuesta = new BLL.AbonoService.Respuesta2();
            respuesta = abonoServicio.Consultar();
            if (!respuesta.IsError)
            {
                List<Abono> listaAuxiliar = new List<Abono>();
                foreach (var item in respuesta.Abonos)
                {
                    if (item.CodigoCuenta == cuenta.Codigo && item.IdCliente == cliente.IdCliente)
                    {
                        listaAuxiliar.Add(item);
                    }
                }

                dtgrAbonos.DataSource = listaAuxiliar ;
                dtgrAbonos.Refresh();
            }
            else
            {
                MessageBox.Show(respuesta.Mensaje, respuesta.Mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void AbrirFormEnPanel(Object formEnPanel)
        {
            
            
        }
        private void BtnDetallesAbono_Click(object sender, EventArgs e)
        {
            
            
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmConsultaAbonos_Load(object sender, EventArgs e)
        {
            
        }
        private void MostrarDatos()
        {
            var respuesta = new BLL.AbonoService.Respuesta2();
            respuesta = abonoServicio.Consultar();
            if (!respuesta.IsError)
            {

                dtgrAbonos.DataSource = respuesta.Abonos;
                dtgrAbonos.Refresh();
            }
            else
            {
                MessageBox.Show(respuesta.Mensaje, respuesta.Mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void BtnDetallesAbono_Click_2(object sender, EventArgs e)
        {
            
        }
        
        private void BtnConsultar_Click(object sender, EventArgs e)
        {
           
            
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {

        }
        private void ButtonVolver_Click(object sender, EventArgs e) {
            Close();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            var resultado = MessageBox.Show("Cerrar el formulario?", "Mensaje de la aplicasion", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == resultado) {
                Close();
            }
        }

        private void ButtonVolver_Click_1(object sender, EventArgs e) {
            Close();
        }

        private void Panel1_Paint_1(object sender, PaintEventArgs e) {

        }

        private void ButtonVolver_Click_2(object sender, EventArgs e) {
            Close();
        }

        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnDetallesAbono_Click_1(object sender, EventArgs e)
        {
            
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAbonar_Click(object sender, EventArgs e)
        {
            frmAbono abono = new frmAbono();
            abono.Show();
        }

        private void BtnModificarAbono_Click(object sender, EventArgs e)
        {
            try
            {
                decimal abono = Convert.ToDecimal(InputDialog.mostrar("Digite el nuevo valor del abono"));
            }
            catch (Exception) { }
        }

        private void Panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void BtnConsultar_Click_1(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MostrarDatos();
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
            respuesta = abonoServicio.Buscar(idCliente);
            if (!respuesta.IsError)
            {
                dtgrAbonos.DataSource = null;
                dtgrAbonos.DataSource = respuesta.Abonos;
                dtgrAbonos.Refresh();
            }
            else
            {
                MessageBox.Show(respuesta.Mensaje, respuesta.Mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
