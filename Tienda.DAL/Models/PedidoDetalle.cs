using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Tienda.DAL.Models
{
    public partial class PedidoDetalle
    {
        public int ProductoId { get; set; }
        public int PedidoId { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }

        //public virtual Pedido Pedido { get; set; }
        //public virtual Producto Producto { get; set; }
    }
}
