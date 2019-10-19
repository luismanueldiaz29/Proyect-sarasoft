using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BLL.ProductoService;
using Entity;
using BLL;

namespace ProyectoTienda {
    public partial class frmProductos : Form {
        ProductoService productoServicio = new ProductoService();
        public frmProductos() {
            InitializeComponent();
        }

        private void TextBox4_TextChanged(object sender, EventArgs e) {

        }

        private void Label7_Click(object sender, EventArgs e) {

        }

        private void Label9_Click(object sender, EventArgs e) {

        }

        private void CmbTipo_SelectedIndexChanged(object sender, EventArgs e) {
            
        }

        private void FrmProductos_Load(object sender, EventArgs e) {
            MostrarDatos();
        }

        private void DtgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void BtnRegistrar_Click(object sender, EventArgs e) {
            RegistrarProducto();
            MostrarDatos();
        }
        private void RegistrarProducto() {
            var respuesta = new Respuesta();
            try {
                if (Convert.ToDecimal(txtCosto.Text) <= 0 || Convert.ToDecimal(txtPrecioCompra.Text) <= 0)
                {
                    MessageBox.Show("¡¡Por favor, ingrese un precio de compra y de venta correctos. No pueden cero");
                }
                else
                {
                    Producto producto = new Producto();
                    producto.Nombre = txtNombre.Text;
                    producto.Categoria = cmbCategoria.Text;
                    producto.Costo = Convert.ToDecimal(txtCosto.Text);
                    producto.PrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text);
                    producto.FechaVencimiento = Convert.ToString(dtmFecha.Text);
                    producto.Presentacion = txtPresentacion.Text;
                    producto.CantidadBodega = Convert.ToInt32(txtCntidadBodega.Text);

                    respuesta = productoServicio.Guardar(producto);
                    MessageBox.Show(respuesta.Mensaje, "Resultado de guardar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            } catch (Exception ex) {

                MessageBox.Show("Verifique los datos digitados " + ex.Message, "Resultado de guardar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e) {
            MostrarDatos();
        }
        private void MostrarDatos() {
            var respuesta = new Respuesta();
            respuesta = productoServicio.Consultar();
            if (!respuesta.IsError) {
                dtgrProductos.DataSource = null;
                dtgrProductos.DataSource = respuesta.productos;
                dtgrProductos.Refresh();
            } else {
                MessageBox.Show(respuesta.Mensaje, respuesta.Mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private bool Validar() {
            if (cmbCategoria.Text == "" || txtNombre.Text == "" || txtCosto.Text == "" || txtPrecioCompra.Text == "" || txtPresentacion.Text == "" || txtCntidadBodega.Text == "") {
                return false;
            } else {
                return true;
            }
        }

        private void DtgrProductos_Click(object sender, EventArgs e) {
            txtNombre.Text = Convert.ToString(dtgrProductos.CurrentRow.Cells["nombre"].Value);
            cmbCategoria.Text = Convert.ToString(dtgrProductos.CurrentRow.Cells["categoria"].Value);
            txtCosto.Text = Convert.ToString(dtgrProductos.CurrentRow.Cells["costo"].Value);
            txtPrecioCompra.Text = Convert.ToString(dtgrProductos.CurrentRow.Cells["preciocompra"].Value);
            txtPresentacion.Text = Convert.ToString(dtgrProductos.CurrentRow.Cells["presentacion"].Value);
            txtCntidadBodega.Text = Convert.ToString(dtgrProductos.CurrentRow.Cells["cantidadbodega"].Value);

            if (cmbCategoria.Text.Equals("Medicamento")) {
                //lblFecha.Visible = true;
                dtmFecha.Visible = true;
                dtmFecha.Text = Convert.ToString(dtgrProductos.CurrentRow.Cells["fechavencimiento"].Value);
            } else {
                //lblFecha.Visible = false;
                dtmFecha.Visible = false;
            }

        }

        private void BtnModificar_Click(object sender, EventArgs e) {
            Modificar();
        }
        private void Modificar() {
            var respuesta = new Respuesta();
            try {
                Producto producto = new Producto();
                producto.Codigo = Convert.ToInt32(dtgrProductos.CurrentRow.Cells["codigo"].Value);
                producto.Nombre = txtNombre.Text;
                producto.Categoria = cmbCategoria.Text;
                producto.Costo = Convert.ToDecimal(txtCosto.Text);
                producto.PrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text);
                producto.FechaVencimiento = Convert.ToString(dtmFecha.Text);
                producto.Presentacion = txtPresentacion.Text;
                producto.CantidadBodega = Convert.ToInt32(txtCntidadBodega.Text);

                respuesta = productoServicio.Modificar(producto);
                
                MessageBox.Show(respuesta.Mensaje, "Resultado de modificar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);


            } catch (Exception ex) {

                MessageBox.Show("Verifique los datos digitados " + ex.Message, "Resultado de guardar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e) {
            Eliminar();
        }
        private void Eliminar() {
            var respuesta = new Respuesta();
            try {
                Producto producto = new Producto();
                LlenarProducto(producto);

                respuesta = productoServicio.Eliminar(producto);
                MessageBox.Show(respuesta.Mensaje, "Resultado de eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            } catch (Exception ex) {

                MessageBox.Show("Verifique los datos digitados " + ex.Message, "Resultado de guardar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void LlenarProducto(Producto producto) {
            producto.Codigo = Convert.ToInt32(dtgrProductos.CurrentRow.Cells["codigo"].Value);
            producto.Nombre = txtNombre.Text;
            producto.Categoria = cmbCategoria.Text;
            producto.Costo = Convert.ToDecimal(txtCosto.Text);
            producto.PrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text);
            producto.FechaVencimiento = Convert.ToString(dtmFecha.Text);
            producto.Presentacion = txtPresentacion.Text;
            producto.CantidadBodega = Convert.ToInt32(txtCntidadBodega.Text);
        }

        private void Panel2_Paint(object sender, PaintEventArgs e) {

        }
        private void Buscar(string nombre)
        {
            var respuesta = new Respuesta();
            respuesta = productoServicio.BuscarXnombre(nombre);
            if (!respuesta.IsError)
            {
                dtgrProductos.DataSource = null;
                dtgrProductos.DataSource = respuesta.productos;
                dtgrProductos.Refresh();
            }
            else
            {
                MessageBox.Show(respuesta.Mensaje, respuesta.Mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TextBox1_TextChanged(object sender, EventArgs e) {
            if (txtBuscarXnombre.Text == "")
            {
                MostrarDatos();
            }
            else
            {
                Buscar(txtBuscarXnombre.Text);
            }
        }

        private void BtnModificar_Click_1(object sender, EventArgs e) {
            var respuesta = new Respuesta();
            try {
                Producto producto = new Producto();
                LlenarProducto(producto);

                respuesta = productoServicio.Modificar(producto);
                MessageBox.Show(respuesta.Mensaje, "Resultado de modificar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                MostrarDatos();
            } catch (Exception ex) {

                MessageBox.Show("Verifique los datos digitados " + ex.Message, "Resultado de guardar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void DtgrProductos_CellClick(object sender, DataGridViewCellEventArgs e) {
            this.txtNombre.Text = Convert.ToString(this.dtgrProductos.CurrentRow.Cells["Nombre"].Value);
            this.cmbCategoria.Text = Convert.ToString(this.dtgrProductos.CurrentRow.Cells["Categoria"].Value);
            this.txtCntidadBodega.Text = Convert.ToString(this.dtgrProductos.CurrentRow.Cells["CantidadBodega"].Value);
            this.txtCosto.Text = Convert.ToString(this.dtgrProductos.CurrentRow.Cells["Costo"].Value);
            
            this.txtPrecioCompra.Text = Convert.ToString(this.dtgrProductos.CurrentRow.Cells["PrecioCompra"].Value);
            this.txtPresentacion.Text = Convert.ToString(this.dtgrProductos.CurrentRow.Cells["Presentacion"].Value);
            if (cmbCategoria.Text.Equals("Medicamento"))
            {
                lblFecha.Visible = true;
                dtmFecha.Visible = true;
                dtmFecha.Text = Convert.ToString(dtgrProductos.CurrentRow.Cells["fechavencimiento"].Value);
            }
            else
            {
                lblFecha.Visible = false;
                dtmFecha.Visible = false;
            }
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e) {
            
        }

        private void TxtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e) {
            if (!Char.IsNumber(e.KeyChar)) {
                if (e.KeyChar != Convert.ToChar(Keys.Back)) {
                    MessageBox.Show("Caracter invalido");
                    e.Handled = true;
                }
            }
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void CmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategoria.Text.Equals("Medicamento"))
            {
                lblFecha.Visible = true;
                dtmFecha.Visible = true;
                lblObligatorio.Visible = true;
            }
            else
            {
                lblFecha.Visible = false;
                dtmFecha.Visible = false;
                lblObligatorio.Visible = false;
            }
        }

        private void TxtCntidadBodega_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar))
            {
                if (e.KeyChar != Convert.ToChar(Keys.Back))
                {
                    MessageBox.Show("Caracter inválido.");
                    e.Handled = true;
                }
            }
        }

        private void TxtCntidadBodega_TextChanged(object sender, EventArgs e)
        {

        }
    }
}