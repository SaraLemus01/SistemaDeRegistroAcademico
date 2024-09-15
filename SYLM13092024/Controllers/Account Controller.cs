using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SYLM13092024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Account_Controller : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login(string login, string password)
        {
            //comprueb si las credenciales son vaalidas
            if (login == "admin" && password == "12345")
            {
                //crea una lista de reclamos (claim)
                var claims = new List<Claim>
                {
                    //agrega una reclamcion de nombre con el valor de "login"
                    new Claim(ClaimTypes.Name, login),

                };
                var claimsIdentity = new ClaimsIdentity(claims,
                   CookieAuthenticationDefaults.AuthenticationScheme);
                // cear propiedades de auenticacion adicionales
                var authProperties = new AuthenticationProperties
                {
                    //puedes configurar propiedades adicionaes aqui
                };

                //inicia sesion del usuario
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), authProperties);

                //devuelve una respuesta existosa
                return Ok("Inicio de seccion correctamente.");
            }
            else
            {
                //devuelve una respuesta no autoizada 
                return Unauthorized("Credenciales incorrectas");
            }
        }
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            //Cierra la secion del usuaio
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok("Cerro sesion correctmente.");
        }
    }
}
