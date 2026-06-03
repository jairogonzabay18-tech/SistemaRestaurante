using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.Entidades
{
    public abstract class Persona
    {
        private int id;
        private string nombre;
        private string apellido;
        private string telefono;
        private string email;
        private DateTime fechaNacimiento;

        public Persona()
        {

        }

        public Persona(int id, string nombre, string apellido,
                       string telefono, string email,
                       DateTime fechaNacimiento)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
            this.email = email;
            this.fechaNacimiento = fechaNacimiento;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }

        public string NombreCompleto()
        {
            return Nombre + " " + Apellido;
        }

        public int Edad()
        {
            int edad = DateTime.Now.Year - FechaNacimiento.Year;

            if (DateTime.Now.Month < FechaNacimiento.Month ||
               (DateTime.Now.Month == FechaNacimiento.Month &&
                DateTime.Now.Day < FechaNacimiento.Day))
            {
                edad--;
            }

            return edad;
        }

        public abstract string ObtenerRol();

        public abstract string ObtenerInfo();

        public override string ToString()
        {
            return NombreCompleto();
        }
    }
}