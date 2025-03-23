using Microsoft.Data.SqlClient;
using Sistema_Citas.Entidades;
using System.Data;

namespace Sistema_Citas.AccesoDatos
{
    public class ServiciosAD
    {
        private readonly BDConexion _BDConnection = new BDConexion();

        #region Carga Datos
        private Servicios CargaServicios(IDataReader Ready)
        {
            return new Servicios
            {
                IdServicio = Convert.ToInt32(Ready["IdServicio"]),
                Nombre = Convert.ToString(Ready["Nombre"]),
                DuracionMinutos = Convert.ToInt32(Ready["DuracionMinutos"]),
                Descripcion = Convert.ToString(Ready["Descripcion"]),
                Estado = Convert.ToInt32(Ready["Estado"]),
                URLimagen = Convert.ToString(Ready["URLimagen"]),
            };
        }

        private UsuariosXServicio CargaUsuariosXServicio(IDataReader Ready)
        {
            return new UsuariosXServicio
            {
                IdUsuario = Convert.ToInt32(Ready["IdUsuario"]),
                Nombre = Convert.ToString(Ready["Nombre"]),
                Telefono = Convert.ToString(Ready["Telefono"]),
                Correo = Convert.ToString(Ready["Correo"]),
            };
        }

        #endregion Carga Datos

        #region Metodos Obtener
        public List<Servicios> ObtenerServicios()
        {
            List<Servicios> ListaServicios = new List<Servicios>();

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_ObtenerServicios";

                SqlDataReader DsReader = cmd.ExecuteReader();

                while (DsReader.Read())
                {
                    ListaServicios.Add(CargaServicios(DsReader));
                }

                conexion.Close();

                return ListaServicios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<UsuariosXServicio> ObtenerUsuariosXServicio(int IdServicio)
        {
            List<UsuariosXServicio> ListaUsuarioXServicio = new List<UsuariosXServicio>();

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_ObtenerUsuariosXServicio";
                cmd.Parameters.AddWithValue("@IdServicio", IdServicio);

                SqlDataReader DsReader = cmd.ExecuteReader();

                while (DsReader.Read())
                {
                    ListaUsuarioXServicio.Add(CargaUsuariosXServicio(DsReader));
                }

                conexion.Close();

                return ListaUsuarioXServicio;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion Metodos Obtener

        #region Metodos Insertar
        public int AgregarServicio(NuevoServicio ElServicio)
        {
            int Resultado = 0;

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_InsertarServicio";
                cmd.Parameters.AddWithValue("@Nombre", ElServicio.Nombre);
                cmd.Parameters.AddWithValue("@Duracion", ElServicio.DuracionMinutos);
                cmd.Parameters.AddWithValue("@Descripcion", ElServicio.Descripcion);
                cmd.Parameters.AddWithValue("@URLimagen", ElServicio.URLimagen);

                cmd.Parameters.Add("@ID", SqlDbType.BigInt);
                cmd.Parameters["@ID"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                Resultado = Convert.ToInt32(cmd.Parameters["@ID"].Value);

                conexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Resultado;
        }

        public int AgregarServicioUsuario(ServicioUsuario ElServicio)
        {
            int Resultado = 0;

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_InsertarServicioUsuario";
                cmd.Parameters.AddWithValue("@IdServicio", ElServicio.IdServicio);
                cmd.Parameters.AddWithValue("@IdUsuario", ElServicio.IdUsuario);

                cmd.Parameters.Add("@ID", SqlDbType.BigInt);
                cmd.Parameters["@ID"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                Resultado = Convert.ToInt32(cmd.Parameters["@ID"].Value);

                conexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Resultado;
        }
        #endregion Metodos Insertar

        #region Metodos Editar
        public int EditarServicio(Servicios ElServicio)
        {
            int Resultado = 0;

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_ModificarServicio";
                cmd.Parameters.AddWithValue("@IdServicio", ElServicio.IdServicio);
                cmd.Parameters.AddWithValue("@Nombre", ElServicio.Nombre);
                cmd.Parameters.AddWithValue("@DuracionMinutos", ElServicio.DuracionMinutos);
                cmd.Parameters.AddWithValue("@Descripcion", ElServicio.Descripcion);
                cmd.Parameters.AddWithValue("@URLimagen", ElServicio.URLimagen);
                cmd.Parameters.AddWithValue("@Estado", ElServicio.Estado);

                cmd.Parameters.Add("@Resultado", SqlDbType.BigInt);
                cmd.Parameters["@Resultado"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                Resultado = Convert.ToInt32(cmd.Parameters["@Resultado"].Value);

                conexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Resultado;
        }
        #endregion Metodos Editar
    }
}
