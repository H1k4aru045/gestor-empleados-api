using MiWebAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace MiWebAPI.Data
{
    public class MobiliarioData
    {

        private readonly string conexion;

        public MobiliarioData(IConfiguration configuration)
        {
            conexion = configuration.GetConnectionString("CadenaSQL")!;
        }

        public async Task<List<Mobiliario>> Lista()
        {
            List<Mobiliario> lista = new List<Mobiliario>();

            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("dbo.Mobiliario_ConsultarTodos", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        lista.Add(new Mobiliario
                        {
                            IdMobiliario = Convert.ToInt64(reader["IdMobiliario"]),
                            Codigo = reader["Codigo"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Material = reader["Material"].ToString(),
                            Color = reader["Color"].ToString(),
                            Costo = Convert.ToDecimal(reader["Costo"]),
                            Activo = Convert.ToBoolean(reader["Activo"]),
                            FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                            FechaActualizacion = reader["FechaActualizacion"] == DBNull.Value ? null : Convert.ToDateTime(reader["FechaActualizacion"])
                        });
                    }
                }
            }
            return lista;
        }

        public async Task<Mobiliario> Obtener(long id)
        {
            Mobiliario objeto = new Mobiliario();

            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("dbo.Mobiliario_ConsultarPorId", con);
                cmd.Parameters.AddWithValue("@IdMobiliario", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        objeto = new Mobiliario
                        {
                            IdMobiliario = Convert.ToInt64(reader["IdMobiliario"]),
                            Codigo = reader["Codigo"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Material = reader["Material"].ToString(),
                            Color = reader["Color"].ToString(),
                            Costo = Convert.ToDecimal(reader["Costo"]),
                            Activo = Convert.ToBoolean(reader["Activo"]),
                            FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                            FechaActualizacion = reader["FechaActualizacion"] == DBNull.Value ? null : Convert.ToDateTime(reader["FechaActualizacion"])
                        };
                    }
                }
            }
            return objeto;
        }

        public async Task<bool> Crear(Mobiliario objeto)
        {
            bool respuesta = true;

            using (var con = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("dbo.Mobiliario_Insertar", con);
                cmd.Parameters.AddWithValue("@Codigo", objeto.Codigo);
                cmd.Parameters.AddWithValue("@Nombre", objeto.Nombre);
                cmd.Parameters.AddWithValue("@Material", objeto.Material);
                cmd.Parameters.AddWithValue("@Color", objeto.Color);
                cmd.Parameters.AddWithValue("@Costo", objeto.Costo);
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

        public async Task<bool> Editar(Mobiliario objeto)
        {
            bool respuesta = true;

            using (var con = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("dbo.Mobiliario_Actualizar", con);
                cmd.Parameters.AddWithValue("@IdMobiliario", objeto.IdMobiliario);
                cmd.Parameters.AddWithValue("@Codigo", objeto.Codigo);
                cmd.Parameters.AddWithValue("@Nombre", objeto.Nombre);
                cmd.Parameters.AddWithValue("@Material", objeto.Material);
                cmd.Parameters.AddWithValue("@Color", objeto.Color);
                cmd.Parameters.AddWithValue("@Costo", objeto.Costo);
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

        public async Task<bool> Eliminar(long id)
        {
            bool respuesta = true;

            using (var con = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("dbo.Mobiliario_Eliminar", con);
                cmd.Parameters.AddWithValue("@IdMobiliario", id);
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