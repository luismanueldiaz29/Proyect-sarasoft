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
using static BLL.CuentaService;
using static BLL.ClienteService;



namespace ProyectoTienda
{
    public partial class frmEstadisticas : Form
    {
        ClienteService clienteServicio = new ClienteService();
        CuentaService cuentaServicio = new CuentaService();
        public frmEstadisticas()
        {
            InitializeComponent();
        }

        private void FrmGraficas_Load(object sender, EventArgs e)
        {
            LlenarGrafica();
            PintarCliente();
        }

        private void BtnLlenarGrafica_Click(object sender, EventArgs e)
        {
            
        }
        private void LlenarGrafica()
        {
            var respuesta = new Respuesta2();
            respuesta = cuentaServicio.ConsultarGraficar();
            chart1.DataSource = respuesta.Cuentas;
            foreach (var item in respuesta.Cuentas)
            {
                chart1.Series["Deuda"].Points.AddXY(item.FechaCreacion, item.ValorDeuda);
            }
            chart1.Titles.Add("Totales producidos por mes");
        }
        private void PintarCliente()
        {
            var respuesta2 = new Respuesta2();
            var respuesta = new Respuesta();
            Cuenta cuenta = new Cuenta();
            Cliente cliente = new Cliente();
            respuesta2 = cuentaServicio.Consultar();
            decimal mayor = 0;
            foreach (var item in respuesta2.Cuentas)
            {
                if (item.TotalFacturas > mayor && item.Estado.Equals("Activa"))
                {
                    mayor = item.TotalFacturas;
                    cuenta = item;
                }
            }
            respuesta = clienteServicio.Consultar();
            foreach (var item in respuesta.Clientes)
            {
                if (item.IdCliente == cuenta.IdCliente)
                {
                    cliente = item;
                }
            }
            Mapear(cliente, cuenta);
        }
        private void Mapear(Cliente cliente, Cuenta cuenta)
        {
            txtIdentificacion.Text = cliente.IdCliente;
            txtPrimerNombre.Text = cliente.Nombre1;
            txtSegundoNombre.Text = cliente.Nombre2;
            txtPrimerApellido.Text = cliente.Apellido1;
            txtSegundoApellido.Text = cliente.Apellido2;
            txtTelefono1.Text = cliente.Telefono1;
            txtTelefono2.Text = cliente.Telefono2;
            txtDireccion.Text = cliente.Direccion;
            txtCorreo.Text = cliente.Correo;
            txtTotal.Text = Convert.ToString(cuenta.TotalFacturas);
        }
    }
}
