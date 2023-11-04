using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TiendaAPI.DTOs;

namespace TiendaAPI.IntegrationTest
{
    [TestClass]
    public class VentaTest
    {
        [TestMethod]

        public async Task ObtenerTokenVenta()
        {
            using var application = new WebApplicationFactory<Program>();
            using var usuario = application.CreateClient();

            var respuesta = await usuario.PostAsJsonAsync("api/login", new UsuarioLogin { NombreUsuario = "Francisco", Clave = "1235" });

            var token = await respuesta.Content.ReadAsStringAsync();

            Assert.IsNotNull(token);
        }

        [TestMethod]

        public async Task ObtenerVentas()
        {
            using var application = new WebApplicationFactory<Program>();
            using var venta = application.CreateClient();
            venta.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRnJhbmNpc2NvIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXN1YXJpbyIsImV4cCI6MTY5OTU5Nzg2NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIzNi8iLCJhdWQiOiJsb2NhbGhvc3QifQ.-CJjeszvbsqMjrwcwwO8M5n0Bl0AW7hIVgFh8XjXxH4");

            var respuesta = await venta.GetFromJsonAsync<List<VentaDTO>>("api/ventas");
            Assert.IsTrue(respuesta != null);
        }

        [TestMethod]
        public async Task ObtenerVentaXId()
        {
            using var application = new WebApplicationFactory<Program>();
            using var venta = application.CreateClient();
            venta.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRnJhbmNpc2NvIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXN1YXJpbyIsImV4cCI6MTY5OTU5Nzg2NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIzNi8iLCJhdWQiOiJsb2NhbGhvc3QifQ.-CJjeszvbsqMjrwcwwO8M5n0Bl0AW7hIVgFh8XjXxH4");

            var respuesta = await venta.GetAsync("api/ventas/1004");
            Assert.IsTrue(respuesta != null);
        }

        [TestMethod]

        public async Task GuardarVenta()
        {
            using var application = new WebApplicationFactory<Program>();
            using var venta = application.CreateClient();
            venta.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRnJhbmNpc2NvIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXN1YXJpbyIsImV4cCI6MTY5OTU5Nzg2NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIzNi8iLCJhdWQiOiJsb2NhbGhvc3QifQ.-CJjeszvbsqMjrwcwwO8M5n0Bl0AW7hIVgFh8XjXxH4");


            var objecto = new GuardarVentaDTO { Usuario_id = 1, Cliente_id = 1002, Producto_id = 2002, Cantidad = 400, Fecha = DateTime.Now };
            var respuesta = await venta.PostAsJsonAsync("api/venta", objecto);

            //var respuesta = await cliente.PostAsJsonAsync("api/categoria", new CategoriaDTO { Nombre = "Prueva de Integracion"});

            Assert.AreEqual(HttpStatusCode.Created, respuesta.StatusCode);
        }

        [TestMethod]

        public async Task ModificarVenta()
        {
            using var application = new WebApplicationFactory<Program>();
            using var venta = application.CreateClient();
            venta.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRnJhbmNpc2NvIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXN1YXJpbyIsImV4cCI6MTY5OTU5Nzg2NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIzNi8iLCJhdWQiOiJsb2NhbGhvc3QifQ.-CJjeszvbsqMjrwcwwO8M5n0Bl0AW7hIVgFh8XjXxH4");


            var objecto = new VentaDTO {Id = 1004, Usuario_id = 1, Cliente_id = 2005, Producto_id = 2005, Cantidad = 200, Fecha = DateTime.Now };
            var respuesta = await venta.PutAsJsonAsync("api/venta/1004", objecto);

            //var respuesta = await cliente.PostAsJsonAsync("api/categoria", new CategoriaDTO { Nombre = "Prueva de Integracion"});

            Assert.AreEqual(HttpStatusCode.OK, respuesta.StatusCode);
        }

        [TestMethod]

        public async Task EliminarVenta()
        {
            using var application = new WebApplicationFactory<Program>();
            using var venta = application.CreateClient();
            venta.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRnJhbmNpc2NvIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXN1YXJpbyIsImV4cCI6MTY5OTU5Nzg2NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIzNi8iLCJhdWQiOiJsb2NhbGhvc3QifQ.-CJjeszvbsqMjrwcwwO8M5n0Bl0AW7hIVgFh8XjXxH4");

            var respuesta = await venta.DeleteAsync("api/venta/1008");

            Assert.AreEqual(HttpStatusCode.NoContent, respuesta.StatusCode);
        }
    }
}
