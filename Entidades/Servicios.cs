namespace Sistema_Citas.Entidades
{
    public class Servicios
    {
        public int IdServicio { get; set; }
        public string Nombre { get; set; }
        public int DuracionMinutos { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
        public string URLimagen { get; set; }
    }

    public class NuevoServicio
    {
        public string Nombre { get; set; }
        public int DuracionMinutos { get; set; }
        public string Descripcion { get; set; }
        public string URLimagen { get; set; }
    }

    public class ServicioUsuario
    {
        public int IdServicio { get; set; }
        public int IdUsuario { get; set; }
    }

    public class UsuariosXServicio
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
}
