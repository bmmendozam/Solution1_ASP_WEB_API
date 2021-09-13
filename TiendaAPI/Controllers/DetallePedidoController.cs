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
    public class DetallePedidoController : ControllerBase
    {
        private IDetallePedidoRepositorio _detallePedidoRepositorio;

        public DetallePedidoController(IDetallePedidoRepositorio detallePedidoRepositorio)
        {
            this._detallePedidoRepositorio = detallePedidoRepositorio;
        }

        // GET: api/DetallePedido
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<PedidoDetalle>>> Get(int id)
        {
            try
            {
                List<PedidoDetalle> detallePedidoAll = await _detallePedidoRepositorio.GetListadoPedidoss (id);
                return detallePedidoAll;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/DetallePedido/1/5
        [HttpGet("{idPedido},{idProd}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PedidoDetalle>> Get(int idPedido,int idProd)
        {
            try
            {
                PedidoDetalle detallePedidoID = await _detallePedidoRepositorio.GetDetallePedidoID(idPedido, idProd);
                return detallePedidoID;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/DetallePedido
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> Post(PedidoDetalle detallePedido)
        {
            try
            {
                bool result = await _detallePedidoRepositorio.Grabar(detallePedido);

                return result;

            }
            catch (Exception)
            {
                return false;
            }
        }

        // DELETE: api/DetallePedido/5
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(PedidoDetalle detallePedido)
        {
            try
            {
                bool resultado = await _detallePedidoRepositorio.Eliminar(detallePedido);
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
