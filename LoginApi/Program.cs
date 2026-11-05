using Microsoft.EntityFrameworkCore;
using LoginApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Agregar soporte para controladores
builder.Services.AddControllers();

// Registrar LoginContext utilizando la cadena de conexión
builder.Services.AddDbContext<LoginContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// [07/10/2026] Se agregó para la herramienta Swagger: registro del servicio de generación de documentación
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // [07/10/2026] Se agregó para la herramienta Swagger: habilitación del middleware y UI de Swagger
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "LoginApi v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();