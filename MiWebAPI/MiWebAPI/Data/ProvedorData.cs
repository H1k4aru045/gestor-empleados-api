using MiWebAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace MiWebAPI.Data
{
    public class ProvedorData
    {

        private readonly string conexion;

        public ProvedorData(IConfiguration configuration)
        {
            conexion = configuration.GetConnectionString("CadenaSQL")!;
        }

        public async Task<List<Provedor>> Lista()
        {
            List<Provedor> lista = new List<Provedor>();

            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("dbo.PROVEDOR_SELECCIONA", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        lista.Add(new Provedor
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString(),
                            ApellidoPaterno = reader["ApellidoPaterno"].ToString(),
                            ApellidoMaterno = reader["ApellidoMaterno"].ToString(),
                            RFC = reader["RFC"].ToString(),
                            Correo = reader["Correo"].ToString(),
                            Credito = Convert.ToDecimal(reader["Credito"]),
                            NombreBanco = reader["NombreBanco"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public async Task<Provedor> Obtener(int id)
        {
            Provedor objeto = new Provedor();

            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("dbo.PROVEDOR_SELECCIONA_POR_ID", con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        objeto = new Provedor
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString(),
                            ApellidoPaterno = reader["ApellidoPaterno"].ToString(),
                            ApellidoMaterno = reader["ApellidoMaterno"].ToString(),
                            RFC = reader["RFC"].ToString(),
                            Correo = reader["Correo"].ToString(),
                            Credito = Convert.ToDecimal(reader["Credito"]),
                            NombreBanco = reader["NombreBanco"].ToString()
                        };
                    }
                }
            }
            return objeto;
        }

        public async Task<bool> Crear(Provedor objeto)
        {
            bool respuesta = true;

            using (var con = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("dbo.PROVEDOR_AGREGA", con);
                cmd.Parameters.AddWithValue("@Nombre", objeto.Nombre);
                cmd.Parameters.AddWithValue("@ApellidoPaterno", objeto.ApellidoPaterno);
                cmd.Parameters.AddWithValue("@ApellidoMaterno", objeto.ApellidoMaterno);
                cmd.Parameters.AddWithValue("@RFC", objeto.RFC);
                cmd.Parameters.AddWithValue("@Correo", objeto.Correo);
                cmd.Parameters.AddWithValue("@Credito", objeto.Credito);
                cmd.Parameters.AddWithValue("@NombreBanco", objeto.NombreBanco);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    await con.OpenAsync();
                    respuesta = await cmd.ExecuteNonQueryAsync() > 0 ? true : false;
                }
                catch
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public async Task<bool> Editar(Provedor objeto)
        {
            bool respuesta = true;

            using (var con = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("dbo.PROVEDOR_ACTUALIZA", con);
                cmd.Parameters.AddWithValue("@Id", objeto.Id);
                cmd.Parameters.AddWithValue("@Nombre", objeto.Nombre);
                cmd.Parameters.AddWithValue("@ApellidoPaterno", objeto.ApellidoPaterno);
                cmd.Parameters.AddWithValue("@ApellidoMaterno", objeto.ApellidoMaterno);
                cmd.Parameters.AddWithValue("@RFC", objeto.RFC);
                cmd.Parameters.AddWithValue("@Correo", objeto.Correo);
                cmd.Parameters.AddWithValue("@Credito", objeto.Credito);
                cmd.Parameters.AddWithValue("@NombreBanco", objeto.NombreBanco);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    await con.OpenAsync();
                    respuesta = await cmd.ExecuteNonQueryAsync() > 0 ? true : false;
                }
                catch
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public async Task<bool> Eliminar(int id)
        {
            bool respuesta = true;

            using (var con = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("dbo.PROVEDOR_ELIMINA", con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    await con.OpenAsync();
                    respuesta = await cmd.ExecuteNonQueryAsync() > 0 ? true : false;
                }
                catch
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
    }
}