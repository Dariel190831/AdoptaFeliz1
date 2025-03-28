using AdoptaFeliz.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using AdoptaFeliz.Services;


var builder = WebApplication.CreateBuilder(args);

//Configurar conexion a DB 
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("SupabaseDB")));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Mi API de Proyecto Base",
        Version = "v1.0",
        Description = "Documentacion de API para proyecto de clase de Programacion Movil"
    });
}
    );

builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<RegistroService>();

var app = builder.Build();
app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAll");
app.Run();
