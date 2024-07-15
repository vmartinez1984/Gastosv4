using AutoMapper;
using gastosv4.Helpers;
using gastosv4.ReglasDeNegocio;
using gastosv4.Repositorios;
using Gastosv4.ReglasDeNegocio;
using Gastosv4.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//inyeccion de repositorios
builder.Services.AddScoped<CategoriaRepositorio>();
builder.Services.AddScoped<SubcategoriaRepositorio>();
builder.Services.AddScoped<Repositorio>();
//fin de repos
//Reglas de negocio
builder.Services.AddScoped<CategoriaRdN>();
builder.Services.AddScoped<SubcategoriaRdN>();
builder.Services.AddScoped<VersionRdN>();
builder.Services.AddScoped<AhorroRdN>();
builder.Services.AddScoped<UnitOfWork>();
//Finde reglas de negocio
//Mappers
var mapperConfig = new MapperConfiguration(mapperConfig =>
{
    mapperConfig.AddProfile<Mapeo>();
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
//fin de mappers

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("*")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithExposedHeaders("*");
    });
});
// fin Cors

//Servicio a DuckbankMs
builder.Services.AddHttpClient();
builder.Services.AddScoped<DuckBankServicio>();

var app = builder.Build();

app.UseCors();
// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
