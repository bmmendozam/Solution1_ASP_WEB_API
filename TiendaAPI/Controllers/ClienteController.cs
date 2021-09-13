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
    public class ClienteController : ControllerBase
    {
        private IClienteRepositorio clienteRepositorio;
        public ClienteController(IClienteRepositorio clienteRepositorio1)
        {
            clienteRepositorio = clienteRepositorio1;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            try
            {
                List<Cliente> ListadoClientes = await clienteRepositorio.GetListadoClientes();
                return ListadoClientes;
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            try
            {
                Cliente cli = await clienteRepositorio.GetClienteID(id);
                return cli;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> Post(Cliente cliente)
        {
            try
            {
                bool result = await clienteRepositorio.Grabar(cliente);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async  Task<IActionResult> Delete(int id)
        {
            try 
            {
                bool resultado = await clienteRepositorio.Eliminar(id);

                if (!resultado)
                {
                    return BadRequest();
                }
                return NoContent();
            }
            catch 
            {
                return BadRequest();
            }
        }

    }
}
