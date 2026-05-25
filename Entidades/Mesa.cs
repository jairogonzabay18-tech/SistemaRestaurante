using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.Entidades
{
    public class Mesa
    {
        private int numero;
        private int capacidad;
        private bool disponible;

        public Mesa()
        {

        }

        public Mesa(int numero, int capacidad, bool disponible)
        {
            this.numero = numero;
            this.capacidad = capacidad;
            this.disponible = disponible;
        }

        public int Numero { get => numero; set => numero = value; }
        public int Capacidad { get => capacidad; set => capacidad = value; }
        public bool Disponible { get => disponible; set => disponible = value; }

        public void Reservar()
        {
            Disponible = false;
        }

        public void Liberar()
        {
            Disponible = true;
        }

        public string ImprimirMesa()
        {
            return "MESA\n" +
                   "Número: " + Numero + "\n" +
                   "Capacidad: " + Capacidad + "\n" +
                   "Disponible: " + Disponible;
        }
    }
}
