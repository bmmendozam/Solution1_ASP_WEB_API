using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.DAL.Contratos;
using Tienda.DAL.Models;


namespace TiendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private IProductoRepositorio productoRepositorio;
        public ProductosController(IProductoRepositorio productoRepositorio1)
        {
            productoRepositorio = productoRepositorio1;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Producto>>> Get()
        {
            try
            {
                List<Producto> ListadoProductos = await productoRepositorio.GetListadoProductos();
                return ListadoProductos;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Producto>> Get(int id)
        {
            try
            {
                Producto pro = await productoRepositorio.GetProductoID(id);
                return pro;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> Post(Producto producto)
        {
            try
            {
                bool result = await productoRepositorio.Grabar(producto);
                return result;
            }
            catch
            {

                return false;
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        { 
            try
            {
                bool resultado = await productoRepositorio.Eliminar(id);
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
