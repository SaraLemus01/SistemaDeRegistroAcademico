using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SYLM13092024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotaController : ControllerBase
    {// Crear una lista para almacenar las notas
        static List<string> notas = new List<string>();
        [HttpGet]
        
        [HttpGet("obtenerNotas")]
        public IActionResult ObtenerNotas()
        {
            return Ok(notas);
        }

        [HttpPost("registrarNotas")]
        public IActionResult RegistrarNotas([FromBody] string nota)
        {
            if (string.IsNullOrWhiteSpace(nota))
            {
                return BadRequest("La nota no puede estar vacía.");
            }

            notas.Add(nota);
            return Ok("Nota registrada exitosamente.");
        }
    }
}
