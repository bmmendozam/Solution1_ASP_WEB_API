using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda.DAL.Models;

namespace Tienda.DAL.Contratos
{
    public interface IPedidoRepositorio : IRepositorioGenerico<Pedido>
    {
        Task<Pedido> GetPedidoID(int id);
        Task<List<Pedido>> GetListadoPedidoss();
        Task<int> GrabarPedido(Pedido entity);
    }
}
