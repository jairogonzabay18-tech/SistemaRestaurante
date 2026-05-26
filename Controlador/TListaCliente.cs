using SistemaRestaurante.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRestaurante.Controlador
{
    public class TListaCliente
    {
        public static List<Cliente> Lista = new List<Cliente>();

        public static void Insert(Cliente op)
        {
            if (op != null)
                Lista.Add(op);
            else
                MessageBox.Show("Objeto null");
        }

        public static void Update(int pos, Cliente op)
        {
            if (pos >= 0 && op != null)
                Lista[pos] = op;
            else
                MessageBox.Show("Posición negativa o objeto null");
        }

        public static void Delete(int pos)
        {
            if (pos >= 0)
                Lista.RemoveAt(pos);
            else
                MessageBox.Show("Posición negativa");
        }

        public static Cliente GetCliente(int pos)
        {
            if (pos >= 0 && pos < Lista.Count)
                return Lista[pos];
            else
                return null;
        }

        public static int Buscar(int idCliente)
        {
            for (int i = 0; i < Lista.Count; i++)
            {
                if (Lista[i].IdCliente == idCliente)
                    return i;
            }

            return -1;
        }
    }
}
