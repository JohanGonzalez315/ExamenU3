using System;
namespace ExamenU3
{
     public class Pedido
    {
        public int Id { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Direccion { get; set; }
        public decimal TotalPagar { get; set; }
        public string MetodoPago { get; set; }
    }
}

