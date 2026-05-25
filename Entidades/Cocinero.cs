using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.Entidades
{
    public class Cocinero : Empleado
    {
        private string especialidad;
        private int experiencia;

        public Cocinero()
        {

        }

        public Cocinero(int id, string nombre, string apellido,
                         string telefono, string email,
                         DateTime fechaNacimiento,
                         int idEmpleado,
                         decimal salario,
                         string turno,
                         DateTime fechaContrato,
                         string especialidad,
                         int experiencia)
            : base(id, nombre, apellido, telefono, email,
                   fechaNacimiento, idEmpleado,
                   salario, turno, fechaContrato)
        {
            this.especialidad = especialidad;
            this.experiencia = experiencia;
        }

        public string Especialidad { get => especialidad; set => especialidad = value; }
        public int Experiencia { get => experiencia; set => experiencia = value; }

        public decimal BonoExperiencia()
        {
            return Experiencia >= 5 ? 200m : 50m;
        }

        public override decimal CalcularSalario()
        {
            return Salario + BonoExperiencia() + BonoAntiguedad();
        }

        public override string ObtenerRol()
        {
            return "Cocinero";
        }

        public override string ObtenerInfo()
        {
            return "COCINERO\n" +
                   "Nombre: " + NombreCompleto() + "\n" +
                   "Especialidad: " + Especialidad + "\n" +
                   "Experiencia: " + Experiencia + " años\n" +
                   "Turno: " + Turno + "\n" +
                   "Salario Total: $" + CalcularSalario();
        }
    }
}
