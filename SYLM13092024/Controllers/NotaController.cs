using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SYLM13092024.Controllers
// Crear el controlador de Nota con los siguiente endpoints:
// ObtenerNotas(Publicó), RegistrarNotas(Privado solo con acceso)
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaController : ControllerBase
    {
      static List<object> Notes = new List<object>(); 
        

        [HttpGet]
        //Permite el acceso publico
        [AllowAnonymous]
        public IActionResult ObtenerNotas()
        {
            return Ok(Notes);
        }

        [HttpPost("registrarnotas")]
        [Authorize]
        public IActionResult RegistrarNotas([FromBody] string note)
        {
            Notes.Add(note);
            return Ok("Nota registrada.");
        }
    }
}
