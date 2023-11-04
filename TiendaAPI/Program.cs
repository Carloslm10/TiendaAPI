using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using TiendaAPI.Context;
using TiendaAPI.Enpoints;
using TiendaAPI.Respositories;
using TiendaAPI.Respositories.Interfaces;
using TiendaAPI.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(o => {
    o.UseSqlServer(builder.Configuration.GetConnectionString("DbConnetion"));
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//Repositorio para intanciar un servicio o inyectarlo dentro de los empoitns
builder.Services.AddScoped<ICliente, ClienteRepository>();
builder.Services.AddScoped<IUsuario, UsuarioRepository>();
builder.Services.AddScoped<IVenta, VentaRepository>();
builder.Services.AddScoped<IProducto, ProductoRepository>();
builder.Services.AddScoped<IMarca, MarcaRepository>();
builder.Services.AddScoped<ICategoria, CategoriaRepository>();



builder.Services.Configure<TokenSetting>(builder.Configuration.GetSection("TokenSetting"));
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidIssuer = builder.Configuration.GetSection("TokenSetting").GetValue<String>("Issuer"),
            ValidateIssuer = true,
            ValidAudience = builder.Configuration.GetSection("TokenSetting").GetValue<String>("Audience"),
            ValidateAudience = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("TokenSetting").GetValue<String>("Key"))),
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
        };
    });

builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Producto API", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Introducir Token",
        Name = "Autorizacion",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
        {
             new OpenApiSecurityScheme {
                 Reference = new OpenApiReference {
                 Type = ReferenceType.SecurityScheme,
                 Id = "Bearer"
                 }
            },
            new String []{}
        }
    });
});

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

public partial class Program
{

}
