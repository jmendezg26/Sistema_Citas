using Sistema_Citas.AccesoDatos;
using Sistema_Citas.Entidades;

namespace Sistema_Citas.LogicaNegocio
{
    public class UsuariosLN
    {
        private readonly UsuariosAD _UsuariosAD = new UsuariosAD();

        #region Metodos Obtener
        public UsuarioLogin IniciarSesion(string Correo, string Clave)
        {

            UsuarioLogin ElUsuario = new UsuarioLogin();
            try
            {
                ElUsuario = _UsuariosAD.IniciarSesion(Correo, Clave);

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
                ListaUsuarios = _UsuariosAD.ObtenerUsuarios();

                return ListaUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

            #endregion Metodos Obtener

        }
}
