using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda.DAL.Models;

namespace Tienda.DAL.Contratos
{
    //le decimos a la interfaz que reciba objeto tipo clase
    //<T> where T: class
    public interface IRepositorioGenerico<T> where T: class
    {
        Task<bool> Grabar(T entity);
        Task<bool> Eliminar(int id);
    }
}
