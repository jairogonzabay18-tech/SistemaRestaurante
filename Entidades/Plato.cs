using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.Entidades
{
    public class Plato
    {
        private int id;
        private string nombre;
        private string descripcion;
        private decimal precio;
        private string categoria;
        private bool disponible;
        private int stock;

        public Plato()
        {

        }

        public Plato(int id, string nombre, string descripcion,
                     decimal precio, string categoria,
                     bool disponible, int stock)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.categoria = categoria;
            this.disponible = disponible;
            this.stock = stock;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public bool Disponible { get => disponible; set => disponible = value; }
        public int Stock { get => stock; set => stock = value; }

        public decimal ObtenerPrecio()
        {
            return Precio;
        }

        public void CambiarDisponibilidad()
        {
            Disponible = !Disponible;
        }

        public void DisminuirStock(int cantidad)
        {
            if (Stock >= cantidad)
            {
                Stock -= cantidad;
            }
        }

        public string ImprimirPlato()
        {
            return "PLATO\n" +
                   "Nombre: " + Nombre + "\n" +
                   "Descripción: " + Descripcion + "\n" +
                   "Categoría: " + Categoria + "\n" +
                   "Precio: $" + Precio + "\n" +
                   "Stock: " + Stock + "\n" +
                   "Disponible: " + Disponible;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
