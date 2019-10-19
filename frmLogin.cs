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
using static BLL.VendedorService;
using Entity;

namespace ProyectoTienda {
    public partial class frmLogin : Form {
        BLL.VendedorService vendedorServicio = new BLL.VendedorService();
        public frmLogin() {
            InitializeComponent();
        }

        private void Btnlogin_Click(object sender, EventArgs e) {
            
        }

        private void Btncerrar_Click(object sender, EventArgs e) {
            
            Application.Exit();
        }

        private void Btnminimizar_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }

        private void TxtUsuario_Enter(object sender, EventArgs e) {
            if (txtUsuario.Text == "USUARIO") {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            } 
        }

        private void TxtUsuario_Leave(object sender, EventArgs e) {
            if (txtUsuario.Text == "") {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

     

        private void TxtUsuario_TextChanged(object sender, EventArgs e) {

        }

        private void TxtPasswork_Enter_1(object sender, EventArgs e) {
            if (txtPasswork.Text == "CONTRASEÑA") {
                txtPasswork.Text = "";
                txtPasswork.ForeColor = Color.LightGray;
                if (!checkBox1.Checked) {
                    txtPasswork.UseSystemPasswordChar = true;
                }
            }
        }

        private void TxtPasswork_Leave_2(object sender, EventArgs e) {
             if (txtPasswork.Text == "") {
                txtPasswork.Text = "CONTRASEÑA";
                txtPasswork.ForeColor = Color.DimGray;
                txtPasswork.UseSystemPasswordChar = false;
            }
        }

        private void Panel2_Paint(object sender, PaintEventArgs e) {

        }

        private void Btnlogin_Click_1(object sender, EventArgs e) {
            /*string Password = "123";
            string Usuario = "admin";
            if (Password == txtPasswork.Text && Usuario == txtUsuario.Text) {
                frmPrincipal frmPrincipal = new frmPrincipal();
                frmPrincipal.Show();
                Hide();
            } else {
                MessageBox.Show("Incorrecto");
            }*/
            Vendedor vendedor = vendedorServicio.Buscar( txtUsuario.Text.Trim(), txtPasswork.Text.Trim());
            if (vendedor != null)
            {
                frmPrincipal frmPrincipal = new frmPrincipal(vendedor);
                frmPrincipal.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Incorrecto");
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e) {
            if (checkBox1.Checked) {
                txtPasswork.UseSystemPasswordChar = false;
            } else {
                if (txtPasswork.Text != "CONTRACEÑA") 
                    txtPasswork.UseSystemPasswordChar = true;
            }
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Panel2_MouseMove(object sender, MouseEventArgs e) {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
