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
using static BLL.ProductoService;
using static BLL.FacturaService;


namespace ProyectoTienda
{
    public partial class frmVentas : Form, IRecibe
    {
        ProductoService productoServicio = new ProductoService();
        FacturaService facturaServicio = new FacturaService();
        CuentaService cuentaServico = new CuentaService();
        DetalleFacturaService detalleServicio = new DetalleFacturaService();
        IList<DtoDetalle> detalles = new List<DtoDetalle>();
        IList<Producto> listaAuxiliar = new List<Producto>();
        Vendedor vendedor = new Vendedor();
        public frmVentas()
        {
            InitializeComponent();
            
        }
        public frmVentas(Vendedor vendedor)
        {
            InitializeComponent();
            this.vendedor = vendedor;
            var respuesta = productoServicio.Consultar();
            listaAuxiliar = respuesta.productos;
        }

        public void Recibir(Cliente cliente) {
            if(cliente!= null) {
                txtIdentificacion.Text = cliente.IdCliente;
                txtApellido.Text = cliente.Apellido1;
                txtDireccion.Text = cliente.Direccion;
                txtNombre.Text = cliente.Nombre1;
                txtTelefono.Text = cliente.Telefono1;
            }
        }
        private void MapearDetalle(Detalle detalle, int i)
        {
            try
            {
                detalle.CodigoProducto = detalles[i].CodigoProducto;
                detalle.NombreProducto = detalles[i].NombreProducto;
                detalle.Categoria = detalles[i].Categoria;
                detalle.CantidadVendida = detalles[i].CantidadVendida;
                detalle.Costo = detalles[i].Costo;
                detalle.SubTotal = detalles[i].SubTotal;
                detalle.Presentacion = detalles[i].Presentacion;
            }
            catch (Exception) { }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (txtIdentificacion.Text == "")
            {
                MessageBox.Show("¡¡Por favor, asegúrese de elejir un cliente al cual registrar la compra");
            }
            else
            {
                var respuesta = new Respuesta2();

                try
                {
                    Factura factura = new Factura();
                    Asignar(factura);
                    respuesta = facturaServicio.Guardar(factura);
                    for (int i = 0; i <= detalles.Count; i++)
                    {
                        Detalle detalle = new Detalle();
                        MapearDetalle(detalle, i);
                        detalleServicio.Guardar(detalle);

                    }



                    MessageBox.Show(respuesta.Mensaje, "Resultado de guardar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);



                }
                catch (Exception ex)
                {

                    MessageBox.Show("Asegúrese de establecer una lista de compras. "+ex.Message, "Resultado de guardar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }
        }
        private void Asignar(Factura factura)
        {
            var respuesta = cuentaServico.Consultar();
            IList<Cuenta> listaAuxiliar = respuesta.Cuentas;

            factura.Fecha = DateTime.Now.ToShortDateString();
            factura.TotalPagar = Convert.ToDecimal(txtTotal.Text);
            factura.IdCliente = txtIdentificacion.Text;
            foreach (var item in listaAuxiliar)
            {
                if (factura.IdCliente == item.IdCliente && item.Estado.Equals("Activa"))
                {
                    factura.CodigoCuenta = item.Codigo;
                }
            }
            
            factura.IdVendedor = vendedor.IdVendedor;
        }
        private void AbrirFrmFactura()
        {
            
        }
        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (dtgrCatalogo.SelectedRows.Count > 0)
            {
                
                int codigo = Convert.ToInt32(dtgrCompra.CurrentRow.Cells["codigoproducto"].Value);
                DtoDetalle detalle = new DtoDetalle();
                foreach (var item in detalles)
                {
                    if (item.CodigoProducto == codigo)
                    {
                        detalle = item;
                    }
                }
                
                detalles.Remove(detalle);
                    dtgrCompra.DataSource = null;
                    dtgrCompra.DataSource = detalles;
                    dtgrCompra.Refresh();

                    foreach (var item in listaAuxiliar)
                    {
                        if (item.Codigo == codigo)
                        {
                            item.CantidadBodega = item.CantidadBodega + detalle.CantidadVendida;
                        }
                    }
                    dtgrCatalogo.DataSource = null;
                    dtgrCatalogo.DataSource = listaAuxiliar;
                    dtgrCatalogo.Refresh();
                    txtTotal.Text = Convert.ToString(detalles.Sum(p => p.SubTotal));
                
            }
            else
            {
                MessageBox.Show("Seleccione una fila de la tabla");
            }
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e) {

        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            txtIdentificacion.Enabled = false;
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            var respuesta = new Respuesta();
            respuesta = productoServicio.Consultar();

            if (!respuesta.IsError)
            {
                dtgrCatalogo.DataSource = null;
                dtgrCatalogo.DataSource = respuesta.productos;
                dtgrCatalogo.Refresh();
            }
            else
            {
                MessageBox.Show(respuesta.Mensaje, respuesta.Mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void AbrirFormEnPanel(Object formEnPanel, bool abrir)
        {
            
                frmClientes frmClientes = formEnPanel as frmClientes;

                AddOwnedForm(frmClientes);
                frmClientes.FormBorderStyle = FormBorderStyle.None;
                frmClientes.TopLevel = false;
                frmClientes.Dock = DockStyle.Fill;
                this.Controls.Add(frmClientes);
                this.Tag = frmClientes;
                frmClientes.BringToFront();
                frmClientes.Show();
           
        }
        private void BtnNuevoCliente_Click(object sender, EventArgs e)
        {
            frmClientes frmcliente = new frmClientes(this);

            //frmcliente.txtElejir.Visible = true;
            AbrirFormEnPanel(frmcliente,false);
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e) {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DtgrCatalogo_Click(object sender, EventArgs e)
        {

        }

        private void BtnAñadir_Click(object sender, EventArgs e)
        {
            Añadir();
        }
        private void Añadir()
        {
            if (txtCantidad.Text == "" || Convert.ToInt32(txtCantidad.Text) == 0)
            {
                MessageBox.Show("Asegúrese de ingresar una cantidad a vender válida. No puede ser cero");
            }
            else
            {
                try
                {
                    if (dtgrCatalogo.SelectedRows.Count > 0)
                    {
                        int cantidad = Convert.ToInt32(txtCantidad.Text);
                        int stock = Convert.ToInt32(dtgrCatalogo.CurrentRow.Cells["cantidadbodega"].Value);
                        if (cantidad > stock)
                        {
                            MessageBox.Show("La cantidad solicitada es mayor que la cantidad disponible");
                        }
                        else
                        {
                            int codProducto = Convert.ToInt32(dtgrCatalogo.CurrentRow.Cells["codigo"].Value);
                            char encontro = 'n';
                            foreach (var item in detalles)
                            {
                                if (item.CodigoProducto == codProducto)
                                {
                                    item.CantidadVendida = item.CantidadVendida + Convert.ToInt32(txtCantidad.Text);
                                    item.SubTotal = item.CantidadVendida * item.Costo;
                                    dtgrCompra.DataSource = null;
                                    dtgrCompra.DataSource = detalles;
                                    dtgrCompra.Refresh();
                                    

                                    encontro = 's';
                                }
                            }
                            if (encontro == 'n')
                            {


                                DtoDetalle detalle = new DtoDetalle();
                                detalle.CodigoProducto = codProducto; ;
                                detalle.NombreProducto = Convert.ToString(dtgrCatalogo.CurrentRow.Cells["nombre"].Value);
                                detalle.Categoria = Convert.ToString(dtgrCatalogo.CurrentRow.Cells["categoria"].Value);
                                detalle.Presentacion = Convert.ToString(dtgrCatalogo.CurrentRow.Cells["presentacion"].Value);
                                detalle.CantidadVendida = Convert.ToInt32(txtCantidad.Text);
                                detalle.Costo = Convert.ToDecimal(dtgrCatalogo.CurrentRow.Cells["costo"].Value);
                                detalle.SubTotal = detalle.CantidadVendida * detalle.Costo;

                                detalles.Add(detalle);
                                dtgrCompra.DataSource = null;
                                dtgrCompra.DataSource = detalles;
                                dtgrCompra.Refresh();

                                
                                
                            }
                            foreach (var item in listaAuxiliar)
                            {
                                if (item.Codigo == Convert.ToInt32(dtgrCatalogo.CurrentRow.Cells["codigo"].Value))
                                {
                                    item.CantidadBodega = item.CantidadBodega - Convert.ToInt32(txtCantidad.Text);
                                }
                            }
                            dtgrCatalogo.DataSource = null;
                            dtgrCatalogo.DataSource = listaAuxiliar;
                            dtgrCatalogo.Refresh();
                            txtTotal.Text = Convert.ToString(detalles.Sum(p => p.SubTotal));


                        }


                    }
                    else
                    {
                        MessageBox.Show("Seleccione una fila de la tabla");
                    }
                }
                catch (Exception) { }
            }
        }

        private void TxtIdentificacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {

        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar))
            {
                if (e.KeyChar != Convert.ToChar(Keys.Back))
                {
                    MessageBox.Show("Caracter invalido");
                    e.Handled = true;
                }
            }
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
        private void Buscar(string nombre)
        {
            var respuesta = new Respuesta();
            respuesta = productoServicio.BuscarXnombre(nombre);
            if (!respuesta.IsError)
            {
                dtgrCatalogo.DataSource = null;
                dtgrCatalogo.DataSource = respuesta.productos;
                dtgrCatalogo.Refresh();
            }
            else
            {
                MessageBox.Show(respuesta.Mensaje, respuesta.Mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
