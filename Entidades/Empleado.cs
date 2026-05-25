using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.Entidades
{
    public abstract class Empleado : Persona
    {
        private int idEmpleado;
        private decimal salario;
        private string turno;
        private DateTime fechaContrato;

        public Empleado()
        {

        }

        public Empleado(int id, string nombre, string apellido,
                         string telefono, string email,
                         DateTime fechaNacimiento,
                         int idEmpleado,
                         decimal salario,
                         string turno,
                         DateTime fechaContrato)
            : base(id, nombre, apellido, telefono, email, fechaNacimiento)
        {
            this.idEmpleado = idEmpleado;
            this.salario = salario;
            this.turno = turno;
            this.fechaContrato = fechaContrato;
        }

        public int IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public decimal Salario { get => salario; set => salario = value; }
        public string Turno { get => turno; set => turno = value; }
        public DateTime FechaContrato { get => fechaContrato; set => fechaContrato = value; }

        public decimal BonoAntiguedad()
        {
            int anios = DateTime.Now.Year - FechaContrato.Year;

            return anios >= 5 ? 150m : 0m;
        }

        public abstract decimal CalcularSalario();

        public abstract override string ObtenerRol();

        public abstract override string ObtenerInfo();
    }
}
