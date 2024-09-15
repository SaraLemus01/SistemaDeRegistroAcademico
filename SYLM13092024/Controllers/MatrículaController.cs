using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AutenticacionCookieContrladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MatriculaController : ControllerBase
    {
        private static readonly List<Matricula> matriculas = new List<Matricula>();

        [HttpPost("crearmatricula")]
        public IActionResult CrearMatricula([FromBody] Matricula matricula)
        {
            matriculas.Add(matricula);
            return Ok("Matricula creada");
        }

        [HttpPut("modificarmatricula")]
        public IActionResult ModificarMatricula([FromBody] Matricula matricula)
        {
            var existing = matriculas.FirstOrDefault(m => m.Id == matricula.Id);
            if (existing == null) return NotFound("Matricula no encontrada");

            existing.Curso = matricula.Curso;
            existing.Estudiante = matricula.Estudiante;
            return Ok("Matricula modificada");
        }

        [HttpGet("obtenerpormatricula/{id}")]
        public IActionResult ObtenerPorIdMatricula(int id)
        {
            var matricula = matriculas.FirstOrDefault(m => m.Id == id);
            if (matricula == null) return NotFound("Matricula no encontrada");

            return Ok(matricula);
        }
    }

    public class Matricula
    {
        public int Id { get; set; }
        public string Estudiante { get; set; }
        public string Curso { get; set; }
    }
}

