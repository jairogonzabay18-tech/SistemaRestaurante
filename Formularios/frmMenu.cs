using SistemaRestaurante.Controlador;
using SistemaRestaurante.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRestaurante.Formularios
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        public void CargarDatos()
        {
            TListaCliente.Lista.Clear();
            TListaPlato.Lista.Clear();
            TListaPedido.Lista.Clear();

            TLista.ListaMeseros.Clear();
            TLista.ListaCocineros.Clear();
            TLista.ListaMesas.Clear();
            TLista.ListaPagos.Clear();

            // CLIENTES

            TListaCliente.Insert(new Cliente(1, "Juan", "Perez", "0991111111", "juan@gmail.com", new DateTime(1995, 5, 10), 101, 10));
            TListaCliente.Insert(new Cliente(2, "Maria", "Lopez", "0992222222", "maria@gmail.com", new DateTime(1998, 8, 15), 102, 25));
            TListaCliente.Insert(new Cliente(3, "Carlos", "Mora", "0993333333", "carlos@gmail.com", new DateTime(1992, 11, 20), 103, 15));

            // PLATOS

            TListaPlato.Insert(new Plato(1, "Arroz con Pollo", "Arroz acompañado de pollo", 4.50m, "Plato Fuerte", true, 20));
            TListaPlato.Insert(new Plato(2, "Encebollado", "Encebollado tradicional", 3.75m, "Sopa", true, 15));
            TListaPlato.Insert(new Plato(3, "Jugo de Mora", "Bebida natural", 1.50m, "Bebida", true, 30));

            // MESEROS

            TLista.ListaMeseros.Add(new Mesero(1, "Pedro", "Ruiz", "0996666666", "pedro@gmail.com", new DateTime(1994, 3, 12), 201, 800m, "Mañana", new DateTime(2021, 5, 10), 5, 120m));
            TLista.ListaMeseros.Add(new Mesero(2, "Luis", "Torres", "0997777777", "luis@gmail.com", new DateTime(1996, 7, 8), 202, 850m, "Tarde", new DateTime(2022, 1, 15), 4, 150m));

            // COCINEROS

            TLista.ListaCocineros.Add(new Cocinero(3, "Ana", "Vera", "0998888888", "ana@gmail.com", new DateTime(1988, 4, 15), 301, 1200m, "Mañana", new DateTime(2018, 2, 10), "Comida Ecuatoriana", 8));
            TLista.ListaCocineros.Add(new Cocinero(4, "Miguel", "Sanchez", "0999999999", "miguel@gmail.com", new DateTime(1990, 9, 30), 302, 1250m, "Noche", new DateTime(2020, 7, 5), "Parrilla", 6));

            // MESAS

            TLista.ListaMesas.Add(new Mesa(1, 4, true));
            TLista.ListaMesas.Add(new Mesa(2, 6, true));
            TLista.ListaMesas.Add(new Mesa(3, 8, false));

            // PEDIDOS

            TListaPedido.Insert(new Pedido(
                1,
                TListaCliente.Lista[0],
                TLista.ListaMeseros[0],
                TLista.ListaMesas[0],
                TListaPlato.Lista[0],
                2,
                10m,
                1.50m,
                11.50m,
                "Pendiente",
                DateTime.Now));

            TListaPedido.Insert(new Pedido(
                2,
                TListaCliente.Lista[1],
                TLista.ListaMeseros[1],
                TLista.ListaMesas[1],
                TListaPlato.Lista[1],
                3,
                20m,
                3m,
                23m,
                "Preparando",
                DateTime.Now));

            // PAGOS

            TLista.ListaPagos.Add(new Pago(
                1,
                TListaPedido.Lista[0],
                11.50m,
                "Efectivo",
                DateTime.Now,
                true));

            TLista.ListaPagos.Add(new Pago(
                2,
                TListaPedido.Lista[1],
                23m,
                "Tarjeta",
                DateTime.Now,
                false));
        }

        public void AbrirFormulario(Form formulario)
        {
            panel1.Controls.Clear();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panel1.Controls.Add(formulario);
            panel1.Tag = formulario;

            formulario.Show();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes frm = new frmClientes();

            AbrirFormulario(frm);
        }

        private void platosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPlatos frm = new frmPlatos();

            AbrirFormulario(frm);
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPedidos frm = new frmPedidos();

            AbrirFormulario(frm);
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpleados frm = new frmEmpleados();

            AbrirFormulario(frm);
        }

        private void mesasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMesas frm = new frmMesas();

            AbrirFormulario(frm);
        }

        private void pagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPagos frm = new frmPagos();

            AbrirFormulario(frm);
        }
    }
}
