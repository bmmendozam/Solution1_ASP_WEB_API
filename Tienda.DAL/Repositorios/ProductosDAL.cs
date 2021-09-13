using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

using System.Text;
using System.Threading.Tasks;
using Tienda.DAL.Contratos;
using Tienda.DAL.Models;

namespace Tienda.DAL.Repositorios
{

    public class ProductosDAL: IProductoRepositorio
    {
        private readonly string _cadenaConexion;
        SqlConnection con;
        SqlCommand cmd;
        public ProductosDAL(string CadenaConexion)
        {
            _cadenaConexion = CadenaConexion;
        }


        public async Task<bool> Grabar(Producto entity)
        {
            con = new SqlConnection(_cadenaConexion);
            cmd = new SqlCommand("sp_Add_Producto", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_Producto", entity.ProductoID);
            cmd.Parameters.AddWithValue("@Nom_Producto", entity.NombreProd);
            cmd.Parameters.AddWithValue("@Pre_Producto", entity.PrecioUnit);
            cmd.Parameters.AddWithValue("@Est_Producto", entity.EstadoProd);
            try
            {
                await con.OpenAsync();
                cmd.ExecuteNonQuery();
                con.Close();

                return true;
            }
            catch (Exception)
            {
                con.Close();
                return false;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            con = new SqlConnection(_cadenaConexion);
            cmd = new SqlCommand("sp_Del_Producto", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_Producto", id);
            try
            {
                await con.OpenAsync();
                cmd.ExecuteNonQuery();
                con.Close();

                return true;
            }
            catch (Exception)
            {
                con.Close();
                return false;
            }
        }


        public async Task<List<Producto>> GetListadoProductos()
        {
            List<Producto> GetProductoList = new List<Producto>();
            con = new SqlConnection(_cadenaConexion);
            cmd = new SqlCommand("sp_Get_Producto", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                await con.OpenAsync();
                SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    GetProductoList.Add(new Producto
                    {
                        ProductoID = Convert.ToInt32(sdr["ProductoID"]),
                        NombreProd = sdr["NombreProd"].ToString(),
                        PrecioUnit = Convert.ToDecimal(sdr["PrecioUnit"]),
                        EstadoProd = Convert.ToString(sdr["EstadoProd"])
                    });
                }
                con.Close();
            }
            catch (Exception)
            {
                con.Close();
            }
            return GetProductoList;
        }


        public async Task<Producto> GetProductoID(int id)
        {
            Producto GetProductoID = new Producto();
            con = new SqlConnection(_cadenaConexion);
            
            cmd = new SqlCommand("sp_Get_Producto", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Producto", id);
            try
            {
                await con.OpenAsync();
                SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    GetProductoID.ProductoID = Convert.ToInt32(sdr["ProductoID"]);
                    GetProductoID.NombreProd = sdr["NombreProd"].ToString();
                    GetProductoID.PrecioUnit = Convert.ToDecimal(sdr["PrecioUnit"]);
                    GetProductoID.EstadoProd = Convert.ToString(sdr["EstadoProd"]);
                }
                con.Close();
            }
            catch (Exception)
            {
                con.Close();
            }
            
            return GetProductoID;
        }


    }
}
