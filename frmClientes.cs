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
using static BLL.ClienteService;
using static BLL.CuentaService;

namespace ProyectoTienda
{
    public partial class frmClientes : Form
    {
        ClienteService clienteServicio = new ClienteService();
        CuentaService cuentaServicio = new CuentaService();
        public IRecibe FmrRecibe;
        public frmClientes()
        {
            InitializeComponent();
        }
        public frmClientes(IRecibe fmrventas) {
            InitializeComponent();
            FmrRecibe = fmrventas;
        }
        
        private void MostrarFormulario(Form frm) {
            AddOwnedForm(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            this.Controls.Add(frm);
            this.Tag = frm;
            frm.BringToFront();
            frm.Show();
        }
        

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            frmAbono abono = new frmAbono();
            abono.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            frmCuenta detalle = new frmCuenta();
            MostrarFormulario(detalle);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LblBuscar_Click(object sender, EventArgs e)
        {

        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void Limpiar() {
            txtIdentificacion.Text = string.Empty;
            txtPrimerNombre.Text = string.Empty;
            txtSegundoNombre.Text = string.Empty;
            txtPrimerApellido.Text = string.Empty;
            txtSegundoApellido.Text = string.Empty;
            txtTelefono1.Text = string.Empty;
            txtTelefono2.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtDireccion.Text = string.Empty;
        }

        private bool Validar() {
            if (txtIdentificacion.Text == "" && txtPrimerNombre.Text == "" && txtPrimerApellido.Text == "" && txtSegundoApellido.Text == "" && txtDireccion.Text == "") {
                return false;
            } else {
                return true;
            }
        }
        
        private void Mostrar() {
            var respuesta = new Respuesta();
            respuesta = clienteServicio.Consultar();
            if (!respuesta.IsError) {
                dataGridClientes.DataSource = null;

                dataGridClientes.DataSource = respuesta.Clientes;
                dataGridClientes.Refresh();
            } else {
                MessageBox.Show(respuesta.Mensaje, respuesta.Mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
     

        

        private void MostrarDatos()
        {
            var respuesta = new Respuesta();
            respuesta = clienteServicio.Consultar();
            if (!respuesta.IsError)
            {
                //dataGridClientes.DataSource = null;
                
                dataGridClientes.DataSource = respuesta.Clientes;
                dataGridClientes.Refresh();
            }
            else
            {
                MessageBox.Show(respuesta.Mensaje, respuesta.Mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Button1_Click_1(object sender, EventArgs e) {
            Respuesta respuesta = new Respuesta();
            Infraestructura pdf = new Infraestructura();
            IList<Cliente> clientes = new List<Cliente>();   
            respuesta = clienteServicio.Consultar();
            string ruta = @"sarasoft.pdf";
            pdf.GuardarPdf(respuesta.Clientes, ruta);
        }

        private void BtnRegistrar_Click_1(object sender, EventArgs e) {
            var respuesta = new Respuesta();
            
            try {
                Cliente cliente = new Cliente();
                Asignar(cliente);
                respuesta = clienteServicio.Guardar(cliente);
                if (respuesta.IsError == false)
                {
                    Cuenta cuenta = new Cuenta();
                    MapearCuenta(cuenta);
                    cuentaServicio.Guardar(cuenta);
                    MessageBox.Show(respuesta.Mensaje + ". Se creó una cuenta inicial al cliente ", "Resultado de guardar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    
                    MessageBox.Show("Verifique la información ingresada. "+respuesta.Mensaje, "Resultado de guardar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    Limpiar();
                }
                
            } catch (Exception ex) {

                MessageBox.Show("Verifique los datos digitados " + ex.Message, "Resultado de guardar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            
        }
        private void MapearCuenta(Cuenta cuenta)
        {
            
            cuenta.FechaCreacion = DateTime.Now.ToShortDateString();
            cuenta.Estado = "Activa";
            cuenta.ValorDeuda = 0;
            cuenta.TotalAbonos = 0;
            cuenta.TotalFacturas = 0;
            cuenta.SaldoAnterior = 0;
            cuenta.IdCliente = txtIdentificacion.Text;
        }

        private void BtnModificar_Click_1(object sender, EventArgs e) {
            if (Validar()) {
                Cliente cliente = new Cliente();
                Asignar(cliente);
                Respuesta mensaje = new Respuesta();
                mensaje = clienteServicio.Modificar(cliente);
                MessageBox.Show(mensaje.Mensaje);
                Limpiar();
                Mostrar();
            } else {
                MessageBox.Show("¡¡Por favor, asegúrese de ingresar la información correctamente!!");
            }
            txtIdentificacion.Enabled = true;
        }

        private void Asignar(Cliente cliente) {
            cliente.IdCliente = txtIdentificacion.Text;
            cliente.Nombre1 = txtPrimerNombre.Text;
            cliente.Nombre2 = txtSegundoNombre.Text;
            cliente.Apellido1 = txtPrimerApellido.Text;
            cliente.Apellido2 = txtSegundoApellido.Text;
            
            cliente.Telefono1 = txtTelefono1.Text;
            cliente.Telefono2 = txtTelefono2.Text;
            cliente.Direccion = txtDireccion.Text;
            cliente.Correo = txtCorreo.Text;
        }

        private void BtnEliminar_Click(object sender, EventArgs e) {
            var respuesta = new Respuesta();
            respuesta = clienteServicio.Eliminar(txtIdentificacion.Text);
            MessageBox.Show(respuesta.Mensaje);
            Mostrar();
        }

       

        private void TxtElejir_Click(object sender, EventArgs e) {
            frmVentas frmVentas = new frmVentas();
            if (dataGridClientes.SelectedRows.Count > 0) {
                frmVentas.txtIdentificacion.Text = txtIdentificacion.Text;
                frmVentas.txtNombre.Text = txtPrimerNombre.Text;
                frmVentas.txtApellido.Text = txtSegundoNombre.Text;
                frmVentas.txtTelefono.Text = txtPrimerApellido.Text;
                frmVentas.txtDireccion.Text = txtSegundoApellido.Text;
                MostrarFormulario(frmVentas);
            } else {
                MessageBox.Show("elija un cliente");
            }
        }

        private void Button1_Click(object sender, EventArgs e) {
            Respuesta respuesta = new Respuesta();
            Infraestructura pdf = new Infraestructura();
            IList<Cliente> clientes = new List<Cliente>();
            respuesta = clienteServicio.Consultar();
            string ruta = @"sarasoft.pdf";
            pdf.GuardarPdf(respuesta.Clientes, ruta);
            MessageBox.Show("Documento pdf generado correctamente");
        }

        private void DataGridClientes_MouseDoubleClick(object sender, MouseEventArgs e) {
            this.txtIdentificacion.Text = Convert.ToString(this.dataGridClientes.CurrentRow.Cells["Idcliente"].Value);
            this.txtPrimerNombre.Text = Convert.ToString(this.dataGridClientes.CurrentRow.Cells["Nombre1"].Value);
            this.txtSegundoNombre.Text = Convert.ToString(this.dataGridClientes.CurrentRow.Cells["Nombre2"].Value);
            this.txtPrimerApellido.Text = Convert.ToString(this.dataGridClientes.CurrentRow.Cells["Apellido1"].Value);
            this.txtSegundoApellido.Text = Convert.ToString(this.dataGridClientes.CurrentRow.Cells["Apellido2"].Value);
            this.txtTelefono1.Text = Convert.ToString(this.dataGridClientes.CurrentRow.Cells["Telefono1"].Value);
            this.txtTelefono2.Text = Convert.ToString(this.dataGridClientes.CurrentRow.Cells["Telefono2"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataGridClientes.CurrentRow.Cells["Direccion"].Value);
            this.txtCorreo.Text = Convert.ToString(this.dataGridClientes.CurrentRow.Cells["Correo"].Value);

        }

        private void DataGridClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (FmrRecibe != null)
            {

                Cliente cliente = new Cliente();
                cliente = (Cliente)dataGridClientes.CurrentRow.DataBoundItem;
                FmrRecibe.Recibir(cliente);
                this.Hide();
            }

        }

        private void TxtIdentificacion_KeyPress(object sender, KeyPressEventArgs e) {
            if (!Char.IsNumber(e.KeyChar)) {
                if (e.KeyChar != Convert.ToChar(Keys.Back)) {
                    MessageBox.Show("Caracter invalido");
                    e.Handled = true;
                }
            }
        }

        private void FrmClientes_KeyPress(object sender, KeyPressEventArgs e) {
            if (!Char.IsLetter(e.KeyChar)) {
                if (!Char.IsWhiteSpace(e.KeyChar)) {
                    if (e.KeyChar != Convert.ToChar(Keys.Back)) {
                        MessageBox.Show("Caracter invalido");
                        e.Handled = true;
                    }
                }
            }
        }


        private void TxtCorreo_TextChanged(object sender, EventArgs e) {

        }

        private void TxtDireccion_TextChanged(object sender, EventArgs e) {

        }

        private void FrmClientes_KeyPress_2(object sender, KeyPressEventArgs e) {
            
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Buscar(string nombre)
        {
            var respuesta = new Respuesta();
            respuesta = clienteServicio.Buscar(nombre);
            if (!respuesta.IsError)
            {
                dataGridClientes.DataSource = null;

                dataGridClientes.DataSource = respuesta.Clientes;
                dataGridClientes.Refresh();
            }
            else
            {
                MessageBox.Show(respuesta.Mensaje, respuesta.Mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                Mostrar();
            }
            else
            {
                Buscar(txtBuscar.Text);
            }
        }

        private void BtnCrearCuenta_Click(object sender, EventArgs e)
        {
            if (dataGridClientes.SelectedRows.Count > 0)
            {
                string nombre = Convert.ToString(this.dataGridClientes.CurrentRow.Cells["nombre1"].Value);
                string apellido = Convert.ToString(this.dataGridClientes.CurrentRow.Cells["apellido1"].Value);
                if (MessageBox.Show("Seguro de crear una nueva cuenta al cliente "+nombre+" "+apellido, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var respuesta = new Respuesta();

                    try
                    {
                        string idCliente = Convert.ToString(this.dataGridClientes.CurrentRow.Cells["Idcliente"].Value);

                        cuentaServicio.GuardarNueva(idCliente);
                        MessageBox.Show(respuesta.Mensaje + ". Se creó la cuenta al cliente ", "Resultado de guardar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error de base de datos: " + ex.Message, "Resultado de guardar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione de la tabla el cliente al cual le creará la cuenta");
            }
        }

        private void DataGridClientes_Click(object sender, EventArgs e)
        {
            txtIdentificacion.Text = Convert.ToString(dataGridClientes.CurrentRow.Cells["idcliente"].Value);
            txtPrimerNombre.Text = Convert.ToString(dataGridClientes.CurrentRow.Cells["nombre1"].Value);
            txtSegundoNombre.Text = Convert.ToString(dataGridClientes.CurrentRow.Cells["nombre2"].Value);
            txtPrimerApellido.Text = Convert.ToString(dataGridClientes.CurrentRow.Cells["apellido1"].Value);
            txtSegundoApellido.Text = Convert.ToString(dataGridClientes.CurrentRow.Cells["apellido2"].Value);
            txtTelefono1.Text = Convert.ToString(dataGridClientes.CurrentRow.Cells["telefono1"].Value);
            txtTelefono2.Text = Convert.ToString(dataGridClientes.CurrentRow.Cells["telefono2"].Value);
            txtDireccion.Text = Convert.ToString(dataGridClientes.CurrentRow.Cells["direccion"].Value);
            txtCorreo.Text = Convert.ToString(dataGridClientes.CurrentRow.Cells["correo"].Value);
            txtIdentificacion.Enabled = false;
        }
    }
}
