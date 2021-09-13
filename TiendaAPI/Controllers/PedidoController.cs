using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tienda.DAL.Contratos;
using Tienda.DAL.Models;

namespace TiendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private IPedidoRepositorio _pedidoRepositorio;

        public PedidoController(IPedidoRepositorio pedidoRepositorio)
        {
            this._pedidoRepositorio = pedidoRepositorio;
        }


        // GET: api/Pedido/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pedido>> Get(int id)
        {
            try
            {
                Pedido pedidoID = await _pedidoRepositorio.GetPedidoID(id);
                return pedidoID;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/Pedido
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<int> Post(Pedido pedido)
        {
            try
            {
                int result = await _pedidoRepositorio.GrabarPedido (pedido);

                return 1;// result;

            }
            catch (Exception)
            {
                return -1;
            }
        }

        // DELETE: api/Pedido/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool resultado = await _pedidoRepositorio.Eliminar(id);

                if (!resultado)
                {
                    return BadRequest();
                }
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
