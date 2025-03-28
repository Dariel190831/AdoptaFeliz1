using AdoptaFeliz.Models;
using AdoptaFeliz.Services;
using Microsoft.AspNetCore.Mvc;



namespace AdoptaFeliz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrosController : ControllerBase
    {
        private readonly RegistroService _registrosService;

        public RegistrosController(RegistroService registroService)
        {
            _registrosService = registroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Registro>>> ObtenerRegistros()
        {
            var registros = await _registrosService.Obtenerregistro();
            return Ok(registros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Registro>> ObtenerRegistroPorId(Guid id)
        {
            var registro = await _registrosService.ObtenerregistroPorId(id);
            if (registro == null) return NotFound("Registro no encontrado");

            return Ok(registro);
        }

        [HttpPost]
        public async Task<ActionResult> CrearRegistro([FromBody] Registro registro)
        {
            if (registro == null)
            {
                return BadRequest("Datos del registro vienen vacíos");
            }
            var nuevoRegistro = await _registrosService.CrearRegistro(registro);
            return Ok(nuevoRegistro);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarRegistro(Guid id, [FromBody] Registro registroActualizado)
        {
            if (registroActualizado == null)
            {
                return BadRequest("Datos de registro vienen vacíos");
            }

            var response = await _registrosService.Actualizarregistro(id, registroActualizado);

            if (!response)
            {
                return NotFound("Registro no encontrado en base de datos");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarRegistro(Guid id)
        {
            var response = await _registrosService.EliminarRegistro(id);
            if (!response)
            {
                return NotFound("Registro no encontrado en base de datos");
            }
            return NoContent();
        }
    }
}
