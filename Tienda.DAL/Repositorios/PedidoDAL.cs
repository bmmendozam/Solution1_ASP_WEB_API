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
    public class PedidoDAL : IPedidoRepositorio
    {
        private readonly string _cadenaConexion;
        SqlConnection con;
        SqlCommand cmd;

        public PedidoDAL(string CadenaConexion)
        {
            _cadenaConexion = CadenaConexion;
        }

        public async Task<int> GrabarPedido(Pedido entity)
        {
            int result = 0;
            con = new SqlConnection(_cadenaConexion);
             cmd = new SqlCommand("sp_Add_Pedido", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_Pedido", entity.PedidoID);
            cmd.Parameters.AddWithValue("@Id_Cliente", entity.ClienteID);
            cmd.Parameters.AddWithValue("@Id_Estado", entity.EstadoPedido);
            cmd.Parameters.AddWithValue("@Fec_Pedido", entity.FechaPedido);

            try
            {
                await con.OpenAsync();
                SqlDataReader sdr = await cmd.ExecuteReaderAsync();

                while (sdr.Read())
                {
                    result = Convert.ToInt32(sdr["ID_SCOPE"]);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                con.Close();
                return 0;
            }
            return result;
        }

        public async Task<bool> Eliminar(int id)
        {
            con = new SqlConnection(_cadenaConexion);
            SqlCommand cmd = new SqlCommand("sp_Del_Pedido", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Pedido", id);
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

        public async Task<List<Pedido>> GetListadoPedidos()
        {
            List<Pedido> GetPedidoList = new List<Pedido>();
            con = new SqlConnection(_cadenaConexion);
            cmd = new SqlCommand("sp_Get_Pedido", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                await con.OpenAsync();
                SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    GetPedidoList.Add(new Pedido
                    {
                        PedidoID = Convert.ToInt32(sdr["PedidoID"]),
                        ClienteID = Convert.ToInt32(sdr["ClienteID"]),
                        NombreCliente = sdr["NombreCliente"].ToString(),
                        EstadoPedido = sdr["EstadoPedido"].ToString(),
                        FechaPedido = Convert.ToDateTime(sdr["FechaPedido"]),
                        ValorTotal = Convert.ToDecimal(sdr["ValorTotal"])
                    });
                }
                con.Close();
            }
            catch (Exception)
            {
                con.Close();
            }
            return GetPedidoList;
        }

        public async Task<Pedido> GetPedidoID(int id)
        {
            Pedido GetPedidoID = new Pedido();
            con = new SqlConnection(_cadenaConexion);
             cmd = new SqlCommand("sp_Get_Pedido", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Pedido", id);
            try
            {
                await con.OpenAsync();
                SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    GetPedidoID.PedidoID = Convert.ToInt32(sdr["PedidoID"]);
                    GetPedidoID.ClienteID = Convert.ToInt32(sdr["ClienteID"]);
                    GetPedidoID.NombreCliente = sdr["NombreCliente"].ToString();
                    GetPedidoID.EstadoPedido = sdr["EstadoPedido"].ToString();
                    GetPedidoID.FechaPedido = Convert.ToDateTime(sdr["FechaPedido"]);
                    GetPedidoID.ValorTotal = Convert.ToDecimal(sdr["ValorTotal"]);
                }
                con.Close();
            }
            catch (Exception)
            {
                con.Close();
            }
            return GetPedidoID;
        }

        public Task<bool> Grabar(Pedido entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Pedido>> GetListadoPedidoss()
        {
            throw new NotImplementedException();
        }
    }
}
