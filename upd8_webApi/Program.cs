using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositorio.Implementations;
using Repositorio.Interfaces;
using Servicos.Implementations;
using Servicos.Interfaces;
using System.Text.Json.Serialization;
using upd8_webApi.Data;
using upd8_webApi.Repository.Implementations;
using upd8_webApi.Repository.Interfaces;
using upd8_webApi.Services.Implementations;
using upd8_webApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICidadeService, CidadeService>();
builder.Services.AddScoped<ICidadeRepository, CidadesRepository>();

builder.Services.AddScoped<IEstadoService, EstadoService>();
builder.Services.AddScoped<IEstadoRepository, EstadosRepository>();

builder.Services.AddScoped<IClientesService, ClienteService>();
builder.Services.AddScoped<IClientesRepository, ClientesRepository>();

builder.Services.AddDbContext<upd8_webApiContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
