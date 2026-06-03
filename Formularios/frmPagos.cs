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
    public partial class frmPagos : Form
    {
        public frmPagos()
        {
            InitializeComponent();
        }

        public void CargarCombos()
        {
            comboBox1.DataSource = null;
            comboBox1.DataSource = TListaPedido.Lista;
            comboBox1.DisplayMember = "IdPedido";
        }

        public void Listar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = TLista.ListaPagos.ToList();
        }

        public Pago CrearObjeto()
        {
            int idPago = int.Parse(textBox1.Text);

            Pedido pedido =
                (Pedido)comboBox1.SelectedItem;

            decimal monto =
                decimal.Parse(textBox2.Text);

            string metodo =
                comboBox2.SelectedItem.ToString();

            DateTime fecha =
                dateTimePicker1.Value;

            return new Pago(
                idPago,
                pedido,
                monto,
                metodo,
                fecha,
                false
            );
        }

        public bool Validar()
        {
            return !textBox1.Text.Equals("") &&
                   !textBox2.Text.Equals("") &&
                   comboBox1.SelectedIndex >= 0 &&
                   comboBox2.SelectedIndex >= 0;
        }

        public void Limpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }

        private void frmPagos_Load(object sender, EventArgs e)
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
                    Pago pago = CrearObjeto();

                    pago.ProcesarPago();

                    TLista.ListaPagos.Add(pago);

                    textBox3.Text = pago.Pagado.ToString();

                    Listar();

                    MessageBox.Show("Pago procesado");
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
            if (dataGridView1.CurrentRow != null)
            {
                int pos = dataGridView1.CurrentRow.Index;

                TLista.ListaPagos.RemoveAt(pos);

                Listar();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int pos = dataGridView1.CurrentRow.Index;

                Pago pago = TLista.ListaPagos[pos];

                MessageBox.Show(
                    pago.GenerarRecibo(),
                    "Recibo");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                Pedido p = (Pedido)comboBox1.SelectedItem;

                textBox2.Text = p.Total.ToString();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int pos = e.RowIndex;

            if (pos >= 0)
            {
                Pago pago = TLista.ListaPagos[pos];

                MessageBox.Show(
                    pago.GenerarRecibo(),
                    "Detalle Pago");
            }
        }
    }
}
