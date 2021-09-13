using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Tienda.DAL.Contratos;
using Tienda.DAL.Models;


namespace Tienda.DAL.Repositorios
{
    public class DetallePedidoDAL : IDetallePedidoRepositorio
    {
        private readonly string _cadenaConexion;
        SqlConnection con;
        SqlCommand cmd;

        public DetallePedidoDAL(string cadenac)
        {
            _cadenaConexion = cadenac;
        }

        public async Task<bool> Grabar(PedidoDetalle entity)
        {
            cmd = new SqlCommand("sp_Add_PedidoDetalle", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Pedido", entity.PedidoId);
            cmd.Parameters.AddWithValue("@Id_Producto", entity.ProductoId);
            cmd.Parameters.AddWithValue("@Cant_Prod", entity.Cantidad);
            cmd.Parameters.AddWithValue("@VlrUni_Prod", entity.ValorUnitario);
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


        public async Task<PedidoDetalle> GetDetallePedidoID(int idPedido, int idProducto)
        {

            PedidoDetalle GetDetallePedidoID = new PedidoDetalle();
            using (SqlConnection con = new SqlConnection(_cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_Get_PedidoDetalle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Pedido", idPedido);
                cmd.Parameters.AddWithValue("@Id_Producto", idProducto);
                try
                {
                    await con.OpenAsync();

                    SqlDataReader sdr = await cmd.ExecuteReaderAsync();

                    while (sdr.Read())
                    {
                        GetDetallePedidoID.PedidoId = Convert.ToInt32(sdr["PedidoID"]);
                        GetDetallePedidoID.ProductoId = Convert.ToInt32(sdr["ProductoID"]);
                        GetDetallePedidoID.Cantidad  = Convert.ToInt32(sdr["Cantidad"]);
                        GetDetallePedidoID.ValorUnitario = Convert.ToInt32(sdr["ValorUnitario"]);
                        GetDetallePedidoID.ValorTotal = Convert.ToInt32(sdr["ValorTotal"]);
                    }
                    con.Close();
                }
                catch (Exception)
                {
                    con.Close();
                }
            }
            return GetDetallePedidoID;
        }

        public async Task<List<PedidoDetalle>> GetListadoPedidoss(int idPedido)
        {

            List<PedidoDetalle> GetDetalleList = new List<PedidoDetalle>();

            using (SqlConnection con = new SqlConnection(_cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_Get_PedidoDetalle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Pedido", idPedido);
                try
                {
                    await con.OpenAsync();

                    SqlDataReader sdr = await cmd.ExecuteReaderAsync();

                    while (sdr.Read())
                    {
                        GetDetalleList.Add(new PedidoDetalle
                        {
                            PedidoId = Convert.ToInt32(sdr["PedidoID"]),
                            ProductoId = Convert.ToInt32(sdr["ProductoID"]),
                            Cantidad = Convert.ToInt32(sdr["Cantidad"]),
                            ValorUnitario = Convert.ToInt32(sdr["ValorUnitario"]),
                            ValorTotal = Convert.ToInt32(sdr["ValorTotal"])
                        });
                    }
                    con.Close();
                }
                catch (Exception)
                {
                    con.Close();
                }
            }
            return GetDetalleList;
        }


        public async Task<bool> Eliminar(PedidoDetalle entity)
        {
            con = new SqlConnection(_cadenaConexion);
            cmd = new SqlCommand("sp_Del_PedidoDetalle", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Pedido", entity.PedidoId);
            cmd.Parameters.AddWithValue("@Id_Producto", entity.ProductoId);

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

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
