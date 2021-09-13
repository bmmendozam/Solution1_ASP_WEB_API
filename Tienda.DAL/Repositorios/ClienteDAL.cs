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
    public class ClienteDAL : IClienteRepositorio
    {
        private readonly string _cadenaConexion;
        SqlConnection con;
        SqlCommand cmd;
        public ClienteDAL(string CadenaConexion)
        {
            _cadenaConexion = CadenaConexion;
        }

        public async Task<bool> Grabar(Cliente entity)
        {
            con = new SqlConnection(_cadenaConexion);
            cmd = new SqlCommand("sp_Add_Cliente",con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_cliente", entity.ClienteId);
            cmd.Parameters.AddWithValue("@Nom_Cliente", entity.NombreCli);
            cmd.Parameters.AddWithValue("@Ape_Cliente", entity.ApellidosCli);
            cmd.Parameters.AddWithValue("@Dir_cliente", entity.DireccionCli);
            cmd.Parameters.AddWithValue("@Tel_Cliente", entity.TelefonoCli);
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


        public async Task<Cliente> GetClienteID(int id)
        {
            Cliente GetClienteID = new Cliente();

            SqlDataReader sdr;
            con = new SqlConnection(_cadenaConexion);
            cmd = new SqlCommand("sp_Get_Cliente", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_cliente", id);
            try
            {
                await con.OpenAsync();
                sdr = await cmd.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    GetClienteID.ClienteId = Convert.ToInt32(sdr["ClienteID"]);
                    GetClienteID.NombreCli = sdr["Nombre"].ToString();
                    GetClienteID.ApellidosCli = sdr["Apellidos"].ToString();
                    GetClienteID.DireccionCli = sdr["Direccion"].ToString();
                    GetClienteID.TelefonoCli  = sdr["Telefono"].ToString();
                }
                con.Close();
            }
            catch (Exception)
            {
                con.Close();
            }
            return GetClienteID;
        }

        public async Task<bool> Eliminar(int id)
        {
            con = new SqlConnection(_cadenaConexion);
            cmd = new SqlCommand("sp_Del_Cliente", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_cliente", id);
            try
            {
                await con.OpenAsync();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                con.Close();
                return false;
            }
            return true;
        }

        public async Task<List<Cliente>> GetListadoClientes()
        {
            List<Cliente> ListadoClientes = new List<Cliente>();
            con = new SqlConnection(_cadenaConexion);
            cmd = new SqlCommand("sp_Get_Cliente", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                await con.OpenAsync();
                SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    ListadoClientes.Add( new Cliente 
                        { 
                            ClienteId = Convert.ToInt32(sdr["ClienteID"]),
                            NombreCli = sdr["Nombre"].ToString(),
                            ApellidosCli= sdr["Apellidos"].ToString(),
                            DireccionCli = sdr["Direccion"].ToString(),
                            TelefonoCli = sdr["Telefono"].ToString()
                    }
                    );
                }
                con.Close();
            }
            catch (Exception)
            {
                con.Close();
            }
            return ListadoClientes;
        }
    }
}
