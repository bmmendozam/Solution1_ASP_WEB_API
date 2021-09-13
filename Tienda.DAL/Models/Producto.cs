using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Tienda.DAL.Models
{
    public partial class Producto
    {
        //public Producto()
        //{
        //    PedidoDetalle = new HashSet<PedidoDetalle>();
        //}

        public int ProductoID { get; set; }
        public string NombreProd { get; set; }
        public decimal PrecioUnit { get; set; }
        public string EstadoProd { get; set; }

        //public virtual ICollection<PedidoDetalle> PedidoDetalle { get; set; }
    }
}
