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

        public void AbrirFormulario(Form formulario)
        {
            panel1.Controls.Clear();

            formulario.TopLevel = false;
            formulario.Dock = DockStyle.Fill;

            panel1.Controls.Add(formulario);

            formulario.Show();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            frmClientes frm = new frmClientes();

            AbrirFormulario(frm);
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
