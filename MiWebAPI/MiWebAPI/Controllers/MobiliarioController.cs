using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MiWebAPI.Data;
using MiWebAPI.Models;

namespace MiWebAPI.Controllers
{
    [Route("api/mobiliarios")]
    [ApiController]
    public class MobiliarioController : ControllerBase
    {
        private readonly MobiliarioData _mobiliarioData;
        public MobiliarioController(MobiliarioData mobiliarioData)
        {
            _mobiliarioData = mobiliarioData;
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Mobiliario> Lista = await _mobiliarioData.Lista();
            return StatusCode(StatusCodes.Status200OK, Lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener(long id)
        {
            Mobiliario objeto = await _mobiliarioData.Obtener(id);
            return StatusCode(StatusCodes.Status200OK, objeto);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Mobiliario objeto)
        {
            bool respuesta = await _mobiliarioData.Crear(objeto);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(long id, [FromBody] Mobiliario objeto)
        {
            objeto.IdMobiliario = id;
            bool respuesta = await _mobiliarioData.Editar(objeto);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(long id)
        {
            bool respuesta = await _mobiliarioData.Eliminar(id);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
        }
    }
}