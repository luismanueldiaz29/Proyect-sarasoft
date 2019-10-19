using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Entity;

namespace ProyectoTienda
{
    public partial class frmPrincipal : Form
    {
        Vendedor vendedor = new Vendedor();
        public frmPrincipal()
        {
            InitializeComponent();
        }

        public frmPrincipal(Vendedor vendedor)
        {
            InitializeComponent();
            this.vendedor = vendedor;
            if (vendedor.Cargo.Equals("Administrador"))
            {
                btnVendedores.Visible = true;
            }
            else
            {
                btnVendedores.Visible = false;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmVentas());
        }

        private void AbrirFormEnPanel(Object formEnPanel)
        {
            if (this.panel.Controls.Count > 0)
            {
                this.panel.Controls.RemoveAt(0);
            }
                Form form = formEnPanel as Form;
                form.TopLevel = false;
                form.Dock = DockStyle.Fill;
                this.panel.Controls.Add(form);
                this.panel.Tag = form;
                form.Show();
            
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmProductos());
        }

        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
        private void Consultar()
        {
            LabelTop.Text = "Historial de Abonos";
            frmConsultaAbonos consulta = new frmConsultaAbonos();
            AbrirFormEnPanel(consulta);
        }
        private void BtnAbonar_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnConsultas_Click(object sender, EventArgs e)
        {
            MostrarFrmDetalle();
        }
        private void MostrarFrmDetalle()
        {
            LabelTop.Text = "Formulario de cuentas";
            frmCuenta consulta = new frmCuenta();
            AbrirFormEnPanel(consulta);
        }

        private void ButtonProducto_Click(object sender, EventArgs e) {
            LabelTop.Text = "Formulario de Productos";
            AbrirFormEnPanel(new frmProductos());
        }

        private void ButtonVentas_Click(object sender, EventArgs e) {
            LabelTop.Text = "Formulario de Ventas";
            AbrirFormEnPanel(new frmVentas(vendedor));
        }

        private void ButtonClientes_Click(object sender, EventArgs e) {
            LabelTop.Text = "Formulario de Clientes";
            frmClientes frmclientes = new frmClientes();
            //frmclientes.txtElejir.Visible = false;
            AbrirFormEnPanel(frmclientes);
        }

        private void Button1_Click_1(object sender, EventArgs e) {
            Consultar();
        }

        private void Button2_Click_1(object sender, EventArgs e) {
            MostrarFrmDetalle();
        }

        private void PictureBox2_Click(object sender, EventArgs e) {
            
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void PanelHeader_MouseMove(object sender, MouseEventArgs e) {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void IconCerrar_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Seguro de cerrar sesión?", "titutlo,alerta¡¡¡¡", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                //tus codigos
                this.Close();
                frmLogin login = new frmLogin();
                login.Show();
            }
        }

        private void IconMinimizar_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Button3_Click_1(object sender, EventArgs e) {
            LabelTop.Text = "Formulario Vendedor";
            AbrirFormEnPanel(new frmVendedor());
        }

        private void PictureMenu_Click(object sender, EventArgs e)
        {

        }

        private void PanelHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
