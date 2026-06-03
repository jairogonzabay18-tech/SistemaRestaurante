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
    public partial class frmEmpleados : Form
    {
        public frmEmpleados()
        {
            InitializeComponent();
        }

        public void ListarTodos()
        {
            dataGridView1.DataSource = null;

            var lista = TLista.ListaMeseros
                .Cast<object>()
                .Concat(TLista.ListaCocineros.Cast<object>())
                .ToList();

            dataGridView1.DataSource = lista;
        }

        public void ListarMeseros()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = TLista.ListaMeseros.ToList();
        }

        public void ListarCocineros()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = TLista.ListaCocineros.ToList();
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            //comboBox1.Items.Add("Todos");
            comboBox1.Items.Add("Mesero");
            comboBox1.Items.Add("Cocinero");

            comboBox1.SelectedIndex = 0;

            //ListarTodos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                object obj = dataGridView1.CurrentRow.DataBoundItem;

                if (obj is Mesero m)
                {
                    MessageBox.Show(
                        m.ObtenerInfo(),
                        "Información Mesero");
                }

                if (obj is Cocinero c)
                {
                    MessageBox.Show(
                        c.ObtenerInfo(),
                        "Información Cocinero");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Todos")
            {
                //ListarTodos();
            }
            else if (comboBox1.SelectedItem.ToString() == "Mesero")
            {
                ListarMeseros();
            }
            else
            {
                ListarCocineros();
            }
        }
    }
}
