using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.Entidades
{
    public class Cliente : Persona
    {
        private int idCliente;
        private int puntosFidelidad;

        public Cliente()
        {

        }

        public Cliente(int id, string nombre, string apellido,
                       string telefono, string email,
                       DateTime fechaNacimiento,
                       int idCliente,
                       int puntosFidelidad)
            : base(id, nombre, apellido, telefono, email, fechaNacimiento)
        {
            this.idCliente = idCliente;
            this.puntosFidelidad = puntosFidelidad;
        }

        public int IdCliente { get => idCliente; set => idCliente = value; }
        public int PuntosFidelidad { get => puntosFidelidad; set => puntosFidelidad = value; }

        public override string ObtenerRol()
        {
            return "Cliente";
        }

        public override string ObtenerInfo()
        {
            return "CLIENTE\n" +
                   "Nombre: " + NombreCompleto() + "\n" +
                   "Teléfono: " + Telefono + "\n" +
                   "Email: " + Email + "\n" +
                   "Edad: " + Edad() + "\n" +
                   "Puntos Fidelidad: " + PuntosFidelidad;
        }
    }
}