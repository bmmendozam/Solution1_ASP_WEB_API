using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda.DAL.Models;

namespace Tienda.DAL.Contratos
{
    public interface IProductoRepositorio: IRepositorioGenerico<Producto>
    {
        Task<Producto> GetProductoID(int id);
        Task<List<Producto>> GetListadoProductos();
    }
}
