using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sistema_Citas.Entidades;
using Sistema_Citas.LogicaNegocio;

namespace Sistema_Citas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServiciosController : Controller
    {
        private readonly ServiciosLN _ServiciosLN = new ServiciosLN();

        #region Metodos Obtener
        [HttpGet("ObtenerServicios")]
        public IActionResult ObtenerServicios()
        {
            List<Servicios> ListaServicios = new List<Servicios>();
            try
            {
                ListaServicios = _ServiciosLN.ObtenerServicios();

                if (ListaServicios.Count > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = ListaServicios, success = true }));
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No se pudo obtener la lista de servicios", success = false }));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = "Imposible ejecutar su transación", success = false });
            }
        }
        #endregion Metodos Obtener

        #region Metodos Insertar
        [HttpPost("CrearServicio")]
        public IActionResult CrearServicio([FromBody] NuevoServicio ElServicio)
        {
            int Resultado = 0;
            try
            {
                Resultado = _ServiciosLN.AgregarServicio(ElServicio);

                if (Resultado != 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = ElServicio, success = true }));
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No se pudo crear el servicio", success = false }));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = "Imposible ejecutar su transación", success = false });
            }
        }
        #endregion Metodos Insertar

        #region Metodos Editar
        [HttpPost("EditarServicio")]
        public IActionResult EditarServicio([FromBody] Servicios ElServicio)
        {
            int Resultado = 0;
            try
            {
                Resultado = _ServiciosLN.EditarServicio(ElServicio);

                if (Resultado != 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = ElServicio, success = true }));
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No se pudo modificar el servicio", success = false }));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = "Imposible ejecutar su transación", success = false });
            }
        }
        #endregion Metodos Editar
    }
}
