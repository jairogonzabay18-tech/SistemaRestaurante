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
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private int pos = -1;

        public void Listar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = TListaCliente.Lista.ToList();
        }

        public Cliente CrearObjeto()
        {
            return new Cliente(
                int.Parse(textBox1.Text),
                textBox2.Text,
                textBox3.Text,
                textBox4.Text,
                textBox5.Text,
                dateTimePicker1.Value,
                int.Parse(textBox1.Text),
                int.Parse(textBox6.Text)
            );
        }

        public bool Validar()
        {
            return textBox1.Text != "" &&
                   textBox2.Text != "" &&
                   textBox3.Text != "" &&
                   textBox4.Text != "" &&
                   textBox5.Text != "" &&
                   textBox6.Text != "";
        }

        public void Limpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

            dateTimePicker1.Value = DateTime.Now;

            pos = -1;
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            //CargarDatos();
            Listar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    Cliente cli = CrearObjeto();

                    TListaCliente.Insert(cli);

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
                if (pos >= 0)
                {
                    Cliente cli = CrearObjeto();

                    TListaCliente.Update(pos, cli);

                    Listar();

                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Seleccione un registro");
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
                if (pos >= 0)
                {
                    DialogResult r = MessageBox.Show(
                        "¿Desea eliminar el cliente?",
                        "Eliminar",
                        MessageBoxButtons.YesNo);

                    if (r == DialogResult.Yes)
                    {
                        TListaCliente.Delete(pos);

                        Listar();

                        Limpiar();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un registro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pos = e.RowIndex;

            if (pos >= 0)
            {
                Cliente cli = TListaCliente.GetCliente(pos);

                textBox1.Text = cli.IdCliente.ToString();
                textBox2.Text = cli.Nombre;
                textBox3.Text = cli.Apellido;
                textBox4.Text = cli.Telefono;
                textBox5.Text = cli.Email;
                dateTimePicker1.Value = cli.FechaNacimiento;
                textBox6.Text = cli.PuntosFidelidad.ToString();
            }
        }
    }
}
