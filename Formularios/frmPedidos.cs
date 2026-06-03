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
    public partial class frmPedidos : Form
    {
        public frmPedidos()
        {
            InitializeComponent();
        }

        public void CargarCombos()
        {
            comboBox1.DataSource = null;
            comboBox1.DataSource = TListaCliente.Lista;
            comboBox1.DisplayMember = "Nombre";

            comboBox2.DataSource = null;
            comboBox2.DataSource = TLista.ListaMeseros;
            comboBox2.DisplayMember = "Nombre";

            comboBox3.DataSource = null;
            comboBox3.DataSource = TLista.ListaMesas;
            comboBox3.DisplayMember = "Numero";

            comboBox4.DataSource = null;
            comboBox4.DataSource = TListaPlato.Lista;
            comboBox4.DisplayMember = "Nombre";
        }

        public void Listar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = TListaPedido.Lista.ToList();
        }

        public void Calcular()
        {
            Plato plato = (Plato)comboBox4.SelectedItem;

            int cantidad = int.Parse(textBox2.Text);

            decimal subtotal = plato.Precio * cantidad;

            decimal iva = subtotal * 0.15m;

            decimal total = subtotal + iva;

            textBox3.Text = subtotal.ToString();

            textBox4.Text = iva.ToString();

            textBox5.Text = total.ToString();
        }

        public Pedido CrearObjeto()
        {
            int idPedido = int.Parse(textBox1.Text);

            Cliente cliente =
                (Cliente)comboBox1.SelectedItem;

            Mesero mesero =
                (Mesero)comboBox2.SelectedItem;

            Mesa mesa =
                (Mesa)comboBox3.SelectedItem;

            Plato plato =
                (Plato)comboBox4.SelectedItem;

            int cantidad =
                int.Parse(textBox2.Text);

            decimal subtotal =
                decimal.Parse(textBox3.Text);

            decimal iva =
                decimal.Parse(textBox4.Text);

            decimal total =
                decimal.Parse(textBox5.Text);

            string estado =
                comboBox5.SelectedItem.ToString();

            DateTime fecha =
                dateTimePicker1.Value;

            return new Pedido(
                idPedido,
                cliente,
                mesero,
                mesa,
                plato,
                cantidad,
                subtotal,
                iva,
                total,
                estado,
                fecha
            );
        }

        public bool Validar()
        {
            return !textBox1.Text.Equals("") &&
                   !textBox2.Text.Equals("") &&
                   !textBox3.Text.Equals("") &&
                   !textBox4.Text.Equals("") &&
                   !textBox5.Text.Equals("") &&
                   comboBox1.SelectedIndex >= 0 &&
                   comboBox2.SelectedIndex >= 0 &&
                   comboBox3.SelectedIndex >= 0 &&
                   comboBox4.SelectedIndex >= 0 &&
                   comboBox5.SelectedIndex >= 0;
        }

        public void Limpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
        }

        private void frmPedidos_Load(object sender, EventArgs e)
        {
            CargarCombos();
            Listar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    Pedido p = CrearObjeto();

                    p.Plato.DisminuirStock(p.Cantidad);

                    TListaPedido.Insert(p);

                    Listar();

                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Complete todos los campos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    int pos = dataGridView1.CurrentRow.Index;

                    TListaPedido.Update(pos, CrearObjeto());

                    Listar();

                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    DialogResult r = MessageBox.Show(
                        "¿Desea eliminar el pedido?",
                        "Eliminar",
                        MessageBoxButtons.YesNo);

                    if (r == DialogResult.Yes)
                    {
                        int pos = dataGridView1.CurrentRow.Index;

                        TListaPedido.Delete(pos);

                        Listar();

                        Limpiar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Calcular();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pos = e.RowIndex;

            if (pos >= 0)
            {
                Pedido p = TListaPedido.GetPedido(pos);

                textBox1.Text = p.IdPedido.ToString();

                comboBox1.SelectedItem = p.Cliente;
                comboBox2.SelectedItem = p.Mesero;
                comboBox3.SelectedItem = p.Mesa;
                comboBox4.SelectedItem = p.Plato;

                textBox2.Text = p.Cantidad.ToString();

                textBox3.Text = p.Subtotal.ToString();
                textBox4.Text = p.Iva.ToString();
                textBox5.Text = p.Total.ToString();

                comboBox5.SelectedItem = p.Estado;

                dateTimePicker1.Value = p.FechaHora;
            }
        }
    }
}
