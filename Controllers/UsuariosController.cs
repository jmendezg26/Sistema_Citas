using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sistema_Citas.Entidades;
using Sistema_Citas.LogicaNegocio;

namespace Sistema_Citas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly UsuariosLN _UsuariosLN = new UsuariosLN();

        #region Metodos Obtener
        [HttpGet("IniciarSesion")]
        public async Task<IActionResult> IniciarSesion(string Correo, string Clave)
        {
            UsuarioLogin ElUsuario = new UsuarioLogin();

            try
            {
                ElUsuario = _UsuariosLN.IniciarSesion(Correo, Clave);

                if (ElUsuario.IdUsuario != 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = ElUsuario, success = true }));
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "Credenciales Incorrectas", success = false }));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = "Imposible ejecutar su transación", success = false });
            }
        }

        [HttpGet("ObtenerUsuarios")]
        public IActionResult ObtenerUsuarios()
        {
            List<ObtenerUsuarios> ListaUsuarios = new List<ObtenerUsuarios>();
            try
            {
                ListaUsuarios = _UsuariosLN.ObtenerUsuarios();

                if (ListaUsuarios.Count > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = ListaUsuarios, success = true }));
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No se pudo obtener la lista de usuarios", success = false }));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = "Imposible ejecutar su transación", success = false });
            }
        }

        #endregion Metodos Obtener


    }
}
