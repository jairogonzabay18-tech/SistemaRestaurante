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
    public partial class frmMesas : Form
    {
        public frmMesas()
        {
            InitializeComponent();
        }
        public void Listar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = TLista.ListaMesas.ToList();
        }

        private void frmMesas_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int pos = dataGridView1.CurrentRow.Index;

                Mesa mesa = TLista.ListaMesas[pos];

                if (mesa.Disponible)
                {
                    mesa.Reservar();

                    Listar();

                    MessageBox.Show("Mesa reservada");
                }
                else
                {
                    MessageBox.Show("La mesa ya está ocupada");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int pos = dataGridView1.CurrentRow.Index;

                Mesa mesa = TLista.ListaMesas[pos];

                mesa.Liberar();

                Listar();

                MessageBox.Show("Mesa liberada");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int pos = e.RowIndex;

            if (pos >= 0)
            {
                Mesa mesa = TLista.ListaMesas[pos];

                MessageBox.Show(mesa.ImprimirMesa());
            }
        }
    }
}
