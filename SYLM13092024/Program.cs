//Importa el espacio de nombres necesario para la autenticacion por cookies
using Microsoft.AspNetCore.Authentication.Cookies;
// importar el espacio de nombres necesario para trabjar con JSON
using System.Text.Json;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CONFIGURACION PARA LA AUTENTIFICAION POR COOKIE
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        //cofigura el nombre del parametro de URL para redireccionamiento no autorizado
        options.ReturnUrlParameter = " unauthorized";
        options.Events = new CookieAuthenticationEvents
        {
            OnRedirectToLogin = context =>
            {
                //cambia el codigo de estado a no autorizado
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                //establec el tipo de contenido como JSON
                context.Response.ContentType = "application/json";
                var message = new
                {
                    error = "No autorizado",
                    message = "Debe iniciar sesion para acceder a este recurso. "
                };
                var jsonMessage = JsonSerializer.Serialize(message);
                return context.Response.WriteAsync(jsonMessage);
            }
        };


    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

