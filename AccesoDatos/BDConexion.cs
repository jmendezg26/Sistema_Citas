namespace Sistema_Citas.AccesoDatos
{
    public class BDConexion
    {
        private static IConfiguration _configuration;

        public static void SetDBConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string BD_CONEXION
        {

            get { return _configuration.GetConnectionString("BD_SistemaCitas"); }

        }

        public string DBConnectionApi()
        {
            string conexion = string.Empty;

            try
            {
                conexion = BD_CONEXION;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            return conexion;
        }

        public string GetConnectionString(string connectionName)
        {
            throw new NotImplementedException();
        }

        public interface IDbConnection
        {
            string GetConnectionString(string connectionName);
        }
    }

}
