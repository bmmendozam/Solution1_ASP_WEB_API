using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda.DAL.Models;

namespace Tienda.DAL.Contratos
{
    public interface IDetallePedidoRepositorio : IRepositorioGenerico<PedidoDetalle>
    {
        Task<PedidoDetalle> GetDetallePedidoID(int idPedido, int idProducto);
        Task<List<PedidoDetalle>> GetListadoPedidoss(int idPedido);

        public Task<bool> Eliminar(PedidoDetalle entity);
    }
}
