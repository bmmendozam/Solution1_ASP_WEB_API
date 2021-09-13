using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Tienda.DAL.Models
{
    public partial class Cliente
    {
        ////public Cliente()
        ////{
        ////    Pedido = new HashSet<Pedido>();
        ////}

        public int ClienteId { get; set; }
        public string NombreCli { get; set; }
        public string ApellidosCli { get; set; }
        public string DireccionCli { get; set; }
        public string TelefonoCli { get; set; }

        //public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
