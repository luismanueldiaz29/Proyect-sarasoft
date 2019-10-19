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


namespace ProyectoTienda
{
    public partial class frmDetalleCuenta : Form
    {

        DetalleFacturaService detalleServicio = new DetalleFacturaService();
        FacturaService facturaServicio = new FacturaService();
        ClienteService clienteServicio = new ClienteService();
        Email email = new Email();
        Cliente cliente = new Cliente();
        Cuenta cuenta = new Cuenta();
        public frmDetalleCuenta()
        {
            InitializeComponent();
        }
        public frmDetalleCuenta(Cuenta cuenta, Cliente cliente)
        {
            InitializeComponent();
            this.cuenta = cuenta;
            this.cliente = cliente;
            MapearCajas();
        }
        private void MapearCajas()
        {
            txtIdentificacion.Text = cliente.IdCliente;
            txtNombre.Text = cliente.Nombre1;
            txtApellido.Text = cliente.Apellido1;
            txtDeuda.Text = Convert.ToString(cuenta.ValorDeuda);
            txtEstadoCuenta.Text = cuenta.Estado;
            txtFecha.Text = cuenta.FechaCreacion;
        }

        private void FrmDetalleCompra_Load(object sender, EventArgs e)
        {
            MostrarDatos2();
            //pan.Enabled = true;
        }


        private void ButtonVolver_Click(object sender, EventArgs e) {
            Close();
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void DtgrDettalleFactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void MostrarDatos()
        {
            int codigoFactura = Convert.ToInt32(this.dtgrFactura.CurrentRow.Cells["codigo"].Value);
            var respuesta = new BLL.DetalleFacturaService.Respuesta();
            respuesta = detalleServicio.Consultar();
            if (!respuesta.IsError)
            {
                //dataGridClientes.DataSource = null;

                dtgrDetalleFactura.DataSource = respuesta.Detalles.Where(p => p.CodigoFactura == codigoFactura).ToList();
                dtgrDetalleFactura.Refresh();
            }
            else
            {
                MessageBox.Show(respuesta.Mensaje, respuesta.Mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void BtnCargarDetalles_Click(object sender, EventArgs e)
        {
            MostrarDatos2();
            MostrarDatos();
        }
        private void MostrarDatos2()
        {
            var respuesta = new BLL.FacturaService.Respuesta2();
            respuesta = facturaServicio.Consultar();
            if (!respuesta.IsError)
            {
                //dataGridClientes.DataSource = null;

                dtgrFactura.DataSource = respuesta.Facturas.Where(p => p.CodigoCuenta == cuenta.Codigo).ToList();
                dtgrFactura.Refresh();
            }
            else
            {
                MessageBox.Show(respuesta.Mensaje, respuesta.Mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
        }

       
        private void BtnGrafica_Click_1(object sender, EventArgs e) {
            frmEstadisticas grafica = new frmEstadisticas();
            grafica.Show();
        }

        private void BtnPDF_Click(object sender, EventArgs e) {
            GenerarPDF();
        }
        private void GenerarPDF()
        {
            try
            {
                if (dtgrFactura.SelectedRows.Count > 0)
                {

                    int codFactura = Convert.ToInt32(dtgrFactura.CurrentRow.Cells["codigo"].Value);
                    string fecha = Convert.ToString(dtgrFactura.CurrentRow.Cells["fecha"].Value);
                    var respuesta = new BLL.DetalleFacturaService.Respuesta();
                    Infraestructura pdf = new Infraestructura();
                    IList<Detalle> detalles = new List<Detalle>();
                    respuesta = detalleServicio.Buscar(codFactura);
                    string ruta = @"sarasoft3.pdf";
                    Factura factura = new Factura();
                    factura.Codigo = codFactura;
                    factura.Fecha = fecha;
                    pdf.GuardarFactura(respuesta.Detalles, ruta, factura);

                }
                else
                {
                    MessageBox.Show("Seleccione una fila de la tabla");
                }
            }
            catch (Exception) { }
        }

        private void BtnEnviar_Click_1(object sender, EventArgs e) {
            var respuesta = new Respuesta();
            respuesta = clienteServicio.Consultar();
            string correo = "";
            foreach (var item in respuesta.Clientes)
            {
                if (item.IdCliente == txtIdentificacion.Text)
                {
                    correo = item.Correo;
                }
            }
            GenerarPDF();
            string mensaje = email.EnviarEmail(correo);
            MessageBox.Show(mensaje);
        }

        private void BtnCargarDetalles_Click_1(object sender, EventArgs e) {
            MostrarDatos();
            MostrarDatos2();
        }

        private void TxtIdentificacion_TextChanged(object sender, EventArgs e) {

        }

        private void TxtFecha_TextChanged(object sender, EventArgs e) {

        }

        private void FrmDetalleCuenta_KeyPress(object sender, KeyPressEventArgs e) {
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

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DtgrFactura_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarDatos();
        }

        private void DtgrDetalleFactura_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
