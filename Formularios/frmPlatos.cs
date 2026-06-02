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
    public partial class frmPlatos : Form
    {
        public frmPlatos()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = TListaPlato.Lista.ToList();
        }

        public Plato CrearObjeto()
        {
            int id = int.Parse(textBox1.Text);
            string nombre = textBox2.Text;
            string descripcion = textBox3.Text;
            decimal precio = decimal.Parse(textBox4.Text);
            string categoria = comboBox1.SelectedItem.ToString();
            bool disponible = bool.Parse(comboBox2.SelectedItem.ToString());
            int stock = int.Parse(textBox5.Text);

            return new Plato(
                id,
                nombre,
                descripcion,
                precio,
                categoria,
                disponible,
                stock
            );
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
        }

        public bool Validar()
        {
            return !textBox1.Text.Equals("") &&
                   !textBox2.Text.Equals("") &&
                   !textBox3.Text.Equals("") &&
                   !textBox4.Text.Equals("") &&
                   !textBox5.Text.Equals("") &&
                   comboBox1.SelectedIndex >= 0 &&
                   comboBox2.SelectedIndex >= 0;
        }

        private void frmPlatos_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    TListaPlato.Insert(CrearObjeto());
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

                    TListaPlato.Update(pos, CrearObjeto());

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
                        "¿Desea eliminar el plato?",
                        "Eliminar",
                        MessageBoxButtons.YesNo);

                    if (r == DialogResult.Yes)
                    {
                        int pos = dataGridView1.CurrentRow.Index;
                        TListaPlato.Delete(pos);

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
            Limpiar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pos = e.RowIndex;

            if (pos >= 0)
            {
                Plato p = TListaPlato.GetPlato(pos);

                textBox1.Text = p.Id.ToString();
                textBox2.Text = p.Nombre;
                textBox3.Text = p.Descripcion;
                textBox4.Text = p.Precio.ToString();
                textBox5.Text = p.Stock.ToString();

                comboBox1.SelectedItem = p.Categoria;
                comboBox2.SelectedItem = p.Disponible.ToString();
            }
        }
    }
}
