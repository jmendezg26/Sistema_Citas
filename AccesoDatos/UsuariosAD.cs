using Microsoft.Data.SqlClient;
using Sistema_Citas.Entidades;
using System.Data;

namespace Sistema_Citas.AccesoDatos
{
    public class UsuariosAD
    {

        private readonly BDConexion _BDConnection = new BDConexion();

        #region Carga Datos
        private UsuarioLogin CargaUsuario(IDataReader Ready)
        {
            return new UsuarioLogin
            {
                IdUsuario = Convert.ToInt32(Ready["IdUsuario"]),
                IdRol = Convert.ToInt32(Ready["IdUsuarioRol"]),
                NombreUsuario = Convert.ToString(Ready["Nombre"]),
                Correo = Convert.ToString(Ready["Correo"]),
                Telefono = Convert.ToString(Ready["Telefono"]),
                Cedula = Convert.ToString(Ready["Cedula"]),
                IdEstado = Convert.ToInt32(Ready["IdEstado"]),
            };
        }

        private ObtenerUsuarios CargaUsuarios(IDataReader Ready)
        {
            return new ObtenerUsuarios
            {
                IdUsuario = Convert.ToInt32(Ready["IdUsuario"]),
                Nombre = Convert.ToString(Ready["Nombre"]),
                Cedula = Convert.ToString(Ready["Cedula"]),
                Telefono = Convert.ToString(Ready["Telefono"]),
                Correo = Convert.ToString(Ready["Correo"]),
                IdEstado = Convert.ToInt32(Ready["IdEstado"]),
                FechaRegistro = Convert.ToDateTime(Ready["FechaRegistro"]),
                IdRol = Convert.ToInt32(Ready["Rol"]),
                Clave = Convert.ToString(Ready["Clave"]),
            };
        }


        #endregion Carga Datos

        #region Metodos Obtener
        public UsuarioLogin IniciarSesion(string Correo, string Clave)
        {
            UsuarioLogin ElUsuario = new UsuarioLogin();

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_IniciarSesion";
                cmd.Parameters.AddWithValue("@Correo", Correo);
                cmd.Parameters.AddWithValue("@Clave", Clave);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ElUsuario = CargaUsuario(reader);
                }

                return ElUsuario;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ObtenerUsuarios> ObtenerUsuarios()
        {
            List<ObtenerUsuarios> ListaUsuarios = new List<ObtenerUsuarios>();

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_ObtenerUsuarios";

                SqlDataReader DsReader = cmd.ExecuteReader();

                while (DsReader.Read())
                {
                    ListaUsuarios.Add(CargaUsuarios(DsReader));
                }

                conexion.Close();

                return ListaUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion Metodos Obtener

        #region Metodos Insertar
        public int AgregarUsuario(NuevoUsuario ElUsuario)
        {
            int Resultado = 0;

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_InsertarUsuario";
                cmd.Parameters.AddWithValue("@Nombre", ElUsuario.Nombre);
                cmd.Parameters.AddWithValue("@Cedula", ElUsuario.Cedula);
                cmd.Parameters.AddWithValue("@Telefono", string.IsNullOrEmpty(ElUsuario.Telefono) ? (object)DBNull.Value : ElUsuario.Telefono);
                cmd.Parameters.AddWithValue("@Correo", ElUsuario.Correo);
                cmd.Parameters.AddWithValue("@Clave", ElUsuario.Clave);

                cmd.Parameters.Add("@ID", SqlDbType.BigInt);
                cmd.Parameters["@ID"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                Resultado = Convert.ToInt32(cmd.Parameters["@ID"].Value);

                if (Resultado > 0)
                {
                    UsuarioRol ElUsuarioRol = new UsuarioRol()
                    {
                        IdUsuario = Resultado,
                        IdRol = ElUsuario.IdRol,
                    };

                    InsertarRolUsuario(ElUsuarioRol);
                }

                conexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Resultado;
        }

        public int InsertarRolUsuario(UsuarioRol ElUsuarioRol)
        {
            int Resultado = 0;

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_InsertarUsuarioRol";
                cmd.Parameters.AddWithValue("@IdUsuario", ElUsuarioRol.IdUsuario);
                cmd.Parameters.AddWithValue("@IdRol", ElUsuarioRol.IdRol);

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
    }
}
