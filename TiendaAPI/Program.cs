using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TiendaAPI.Context;
using TiendaAPI.Enpoints;
using TiendaAPI.Respositories;
using TiendaAPI.Respositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(o => {
    o.UseSqlServer(builder.Configuration.GetConnectionString("DbConnetion"))
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//builder.Services.AddScoped<ICliente, ClienteRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseEndpointd();

app.Run();
