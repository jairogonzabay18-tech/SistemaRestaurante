using SistemaRestaurante.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.Controlador
{
    public class TLista
    {
        public static List<Cliente> ListaClientes = new List<Cliente>();
        public static List<Mesero> ListaMeseros = new List<Mesero>();
        public static List<Cocinero> ListaCocineros = new List<Cocinero>();
        public static List<Mesa> ListaMesas = new List<Mesa>();
        public static List<Plato> ListaPlatos = new List<Plato>();
        public static List<Pedido> ListaPedidos = new List<Pedido>();
        public static List<Pago> ListaPagos = new List<Pago>();
    }
}
