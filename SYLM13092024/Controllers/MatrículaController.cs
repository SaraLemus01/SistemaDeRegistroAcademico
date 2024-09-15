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
        // Crear una lista en memoria para almacenar las matrículas
        private static List<object> matriculas = new List<object>();

    }
}

