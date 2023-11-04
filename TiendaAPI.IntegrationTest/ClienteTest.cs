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
    public class ClienteTest
    {
        [TestMethod]

        public async Task ObtenerTokenUsuario()
        {
            using var application = new WebApplicationFactory<Program>();
            using var usuario = application.CreateClient();

            var respuesta = await usuario.PostAsJsonAsync("api/login", new UsuarioLogin { NombreUsuario = "Francisco", Clave = "1235" });

            var token = await respuesta.Content.ReadAsStringAsync();

            Assert.IsNotNull(token);
        }

        [TestMethod]

        public async Task ObtenerCliente()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();
            cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRnJhbmNpc2NvIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXN1YXJpbyIsImV4cCI6MTY5OTU5Nzg2NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIzNi8iLCJhdWQiOiJsb2NhbGhvc3QifQ.-CJjeszvbsqMjrwcwwO8M5n0Bl0AW7hIVgFh8XjXxH4");

            var respuesta = await cliente.GetFromJsonAsync<List<ClienteDTO>>("api/clientes");
            Assert.IsTrue(respuesta != null);
        }

        [TestMethod]
        public async Task ObtenerClienteXId()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();
            cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRnJhbmNpc2NvIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXN1YXJpbyIsImV4cCI6MTY5OTU5Nzg2NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIzNi8iLCJhdWQiOiJsb2NhbGhvc3QifQ.-CJjeszvbsqMjrwcwwO8M5n0Bl0AW7hIVgFh8XjXxH4");

            var respuesta = await cliente.GetAsync("api/clientes/2002");
            Assert.IsTrue(respuesta != null);
        }

        [TestMethod]

        public async Task GuardarCliente()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();
            cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRnJhbmNpc2NvIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXN1YXJpbyIsImV4cCI6MTY5OTU5Nzg2NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIzNi8iLCJhdWQiOiJsb2NhbGhvc3QifQ.-CJjeszvbsqMjrwcwwO8M5n0Bl0AW7hIVgFh8XjXxH4");


            var objecto = new ClienteDTO { Nombre = "Juan", Apellido = "Gomez", Dui = "48526951-9", Direccion = "Sonsonate", Telefono = "2155-5691" };
            var respuesta = await cliente.PostAsJsonAsync("api/cliente", objecto);

            //var respuesta = await cliente.PostAsJsonAsync("api/categoria", new CategoriaDTO { Nombre = "Prueva de Integracion"});

            Assert.AreEqual(HttpStatusCode.Created, respuesta.StatusCode);
        }

        [TestMethod]

        public async Task ModificarCliente()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();
            cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRnJhbmNpc2NvIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXN1YXJpbyIsImV4cCI6MTY5OTU5Nzg2NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIzNi8iLCJhdWQiOiJsb2NhbGhvc3QifQ.-CJjeszvbsqMjrwcwwO8M5n0Bl0AW7hIVgFh8XjXxH4");


            var objecto = new ClienteDTO {Id = 1002, Nombre = "Nahum", Apellido = "Lipe", Dui = "15246843-6", Direccion = "Juayua", Telefono = "1982-6473" };
            var respuesta = await cliente.PutAsJsonAsync("api/cliente/1002", objecto);

            //var respuesta = await cliente.PostAsJsonAsync("api/categoria", new CategoriaDTO { Nombre = "Prueva de Integracion"});

            Assert.AreEqual(HttpStatusCode.OK, respuesta.StatusCode);
        }

        [TestMethod]

        public async Task EliminarCliente()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();
            cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRnJhbmNpc2NvIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXN1YXJpbyIsImV4cCI6MTY5OTU5Nzg2NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIzNi8iLCJhdWQiOiJsb2NhbGhvc3QifQ.-CJjeszvbsqMjrwcwwO8M5n0Bl0AW7hIVgFh8XjXxH4");

            var respuesta = await cliente.DeleteAsync("api/cliente/3007");

            Assert.AreEqual(HttpStatusCode.NoContent, respuesta.StatusCode);
        }
    }

    public class UsuarioLogin
    {
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
    }
}
