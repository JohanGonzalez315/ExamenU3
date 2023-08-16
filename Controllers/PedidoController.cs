using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ExamenU3;

namespace WebApiPedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private static List<Pedido> _pedidos = new List<Pedido>();

        // GET: api/Pedidos
        [HttpGet]
        public ActionResult<IEnumerable<Pedido>> GetPedidos()
        {
            return _pedidos;
        }

        // GET: api/Pedidos/5
        [HttpGet("{id}")]
        public ActionResult<Pedido> GetPedido(int id)
        {
            var pedido = _pedidos.Find(p => p.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }
            return pedido;
        }

        // POST: api/Pedidos
        [HttpPost]
        public ActionResult<Pedido> CreatePedido(Pedido pedido)
        {
            pedido.Id = _pedidos.Count + 1;
            _pedidos.Add(pedido);
            return CreatedAtAction(nameof(GetPedido), new { id = pedido.Id }, pedido);
        }

        // PUT: api/Pedidos/5
        [HttpPut("{id}")]
        public IActionResult UpdatePedido(int id, Pedido updatedPedido)
        {
            var pedido = _pedidos.Find(p => p.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            pedido.FechaSolicitud = updatedPedido.FechaSolicitud;
            pedido.FechaEntrega = updatedPedido.FechaEntrega;
            pedido.Direccion = updatedPedido.Direccion;
            pedido.TotalPagar = updatedPedido.TotalPagar;
            pedido.MetodoPago = updatedPedido.MetodoPago;

            return NoContent();
        }

        // DELETE: api/Pedidos/5
        [HttpDelete("{id}")]
        public IActionResult DeletePedido(int id)
        {
            var pedido = _pedidos.Find(p => p.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            _pedidos.Remove(pedido);
            return NoContent();
        }
    }
}
