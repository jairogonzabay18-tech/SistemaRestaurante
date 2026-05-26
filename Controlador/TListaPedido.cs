using SistemaRestaurante.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRestaurante.Controlador
{
    public class TListaPedido
    {
        public static List<Pedido> Lista = new List<Pedido>();

        public static void Insert(Pedido op)
        {
            if (op != null)
                Lista.Add(op);
            else
                MessageBox.Show("Objeto null");
        }

        public static void Update(int pos, Pedido op)
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

        public static Pedido GetPedido(int pos)
        {
            if (pos >= 0 && pos < Lista.Count)
                return Lista[pos];
            else
                return null;
        }

        public static int Buscar(int idPedido)
        {
            for (int i = 0; i < Lista.Count; i++)
            {
                if (Lista[i].IdPedido == idPedido)
                    return i;
            }

            return -1;
        }
    }
}
