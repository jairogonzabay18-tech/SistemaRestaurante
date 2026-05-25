using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.Entidades
{
    public class Mesero : Empleado
    {
        private int mesasAsignadas;
        private decimal propinas;

        public Mesero()
        {

        }

        public Mesero(int id, string nombre, string apellido,
                       string telefono, string email,
                       DateTime fechaNacimiento,
                       int idEmpleado,
                       decimal salario,
                       string turno,
                       DateTime fechaContrato,
                       int mesasAsignadas,
                       decimal propinas)
            : base(id, nombre, apellido, telefono, email,
                   fechaNacimiento, idEmpleado,
                   salario, turno, fechaContrato)
        {
            this.mesasAsignadas = mesasAsignadas;
            this.propinas = propinas;
        }

        public int MesasAsignadas { get => mesasAsignadas; set => mesasAsignadas = value; }
        public decimal Propinas { get => propinas; set => propinas = value; }

        public override decimal CalcularSalario()
        {
            return Salario + Propinas + BonoAntiguedad();
        }

        public override string ObtenerRol()
        {
            return "Mesero";
        }

        public override string ObtenerInfo()
        {
            return "MESERO\n" +
                   "Nombre: " + NombreCompleto() + "\n" +
                   "Turno: " + Turno + "\n" +
                   "Mesas Asignadas: " + MesasAsignadas + "\n" +
                   "Propinas: $" + Propinas + "\n" +
                   "Salario Total: $" + CalcularSalario();
        }
    }
}
