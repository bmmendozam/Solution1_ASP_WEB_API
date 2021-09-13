using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda.DAL.Models;

namespace Tienda.DAL.Contratos
{
    public interface IClienteRepositorio: IRepositorioGenerico<Cliente>
    {
        Task<Cliente> GetClienteID(int id);
        Task<List<Cliente>> GetListadoClientes();

    }
}
