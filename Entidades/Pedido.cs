using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.Entidades
{
    public class Pedido
    {
        private int idPedido;
        private Cliente cliente;
        private Mesero mesero;
        private Mesa mesa;
        private Plato plato;
        private int cantidad;
        private decimal subtotal;
        private decimal iva;
        private decimal total;
        private string estado;
        private DateTime fechaHora;

        public Pedido()
        {

        }

        public Pedido(int idPedido,
                      Cliente cliente,
                      Mesero mesero,
                      Mesa mesa,
                      Plato plato,
                      int cantidad,
                      decimal subtotal,
                      decimal iva,
                      decimal total,
                      string estado,
                      DateTime fechaHora)
        {
            this.idPedido = idPedido;
            this.cliente = cliente;
            this.mesero = mesero;
            this.mesa = mesa;
            this.plato = plato;
            this.cantidad = cantidad;
            this.subtotal = subtotal;
            this.iva = iva;
            this.total = total;
            this.estado = estado;
            this.fechaHora = fechaHora;
        }

        public int IdPedido { get => idPedido; set => idPedido = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Mesero Mesero { get => mesero; set => mesero = value; }
        public Mesa Mesa { get => mesa; set => mesa = value; }
        public Plato Plato { get => plato; set => plato = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public decimal Subtotal { get => subtotal; set => subtotal = value; }
        public decimal Iva { get => iva; set => iva = value; }
        public decimal Total { get => total; set => total = value; }
        public string Estado { get => estado; set => estado = value; }
        public DateTime FechaHora { get => fechaHora; set => fechaHora = value; }

        public decimal CalcularTotal()
        {
            Iva = Subtotal * 0.15m;
            Total = Subtotal + Iva;

            return Total;
        }

        public void CambiarEstado(string nuevoEstado)
        {
            Estado = nuevoEstado;
        }

        public string ImprimirPedido()
        {
            return "PEDIDO\n" +
                   "Código Pedido: " + IdPedido + "\n" +
                   "Cliente: " + Cliente.NombreCompleto() + "\n" +
                   "Mesero: " + Mesero.NombreCompleto() + "\n" +
                   "Mesa: " + Mesa.Numero + "\n" +
                   "Subtotal: $" + Subtotal + "\n" +
                   "IVA: $" + Iva + "\n" +
                   "Total: $" + Total + "\n" +
                   "Estado: " + Estado;
        }

        public override string ToString()
        {
            return idPedido.ToString();
        }
    }
}