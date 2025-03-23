using Sistema_Citas.AccesoDatos;
using Sistema_Citas.Entidades;

namespace Sistema_Citas.LogicaNegocio
{
    public class ServiciosLN
    {
        private readonly ServiciosAD _ServiciosAD = new ServiciosAD();

        #region Metodos Obtener
        public List<Servicios> ObtenerServicios()
        {
            List<Servicios> ListaServicios = new List<Servicios>();

            try
            {
                ListaServicios = _ServiciosAD.ObtenerServicios();

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
                ListaUsuarioXServicio = _ServiciosAD.ObtenerUsuariosXServicio(IdServicio);

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
                Resultado = _ServiciosAD.AgregarServicio(ElServicio);
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
                Resultado = _ServiciosAD.AgregarServicioUsuario(ElServicio);
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
                Resultado = _ServiciosAD.EditarServicio(ElServicio);
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
