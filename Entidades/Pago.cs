using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.Entidades
{
    public class Pago
    {
        private int idPago;
        private Pedido pedido;
        private decimal monto;
        private string metodoPago;
        private DateTime fechaPago;
        private bool pagado;

        public Pago()
        {

        }

        public Pago(int idPago, Pedido pedido,
                    decimal monto, string metodoPago,
                    DateTime fechaPago, bool pagado)
        {
            this.idPago = idPago;
            this.pedido = pedido;
            this.monto = monto;
            this.metodoPago = metodoPago;
            this.fechaPago = fechaPago;
            this.pagado = pagado;
        }

        public int IdPago { get => idPago; set => idPago = value; }
        public Pedido Pedido { get => pedido; set => pedido = value; }
        public decimal Monto { get => monto; set => monto = value; }
        public string MetodoPago { get => metodoPago; set => metodoPago = value; }
        public DateTime FechaPago { get => fechaPago; set => fechaPago = value; }
        public bool Pagado { get => pagado; set => pagado = value; }

        public bool ProcesarPago()
        {
            if (Monto > 0)
            {
                Pagado = true;
                return true;
            }

            return false;
        }

        public string GenerarRecibo()
        {
            return "RECIBO DE PAGO\n" +
                   "Código Pago: " + IdPago + "\n" +
                   "Pedido: " + Pedido.IdPedido + "\n" +
                   "Monto: $" + Monto + "\n" +
                   "Método de Pago: " + MetodoPago + "\n" +
                   "Fecha: " + FechaPago + "\n" +
                   "Estado: " + Pagado;
        }
    }
}
