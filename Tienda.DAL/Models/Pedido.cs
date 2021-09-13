using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Tienda.DAL.Models
{
    public partial class Pedido
    {
        //public Pedido()
        //{
        //    PedidoDetalle = new HashSet<PedidoDetalle>();
        //}

        public int PedidoID { get; set; }
        public int ClienteID { get; set; }
        public string  NombreCliente { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}",ApplyFormatInEditMode =true)]
        public DateTime FechaPedido { get; set; }
        public string EstadoPedido { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName ="decimal(18,0)")]
        public decimal ValorTotal { get; set; }

        //public virtual Cliente Cliente { get; set; }
        //public virtual ICollection<PedidoDetalle> PedidoDetalle { get; set; }
    }
}
