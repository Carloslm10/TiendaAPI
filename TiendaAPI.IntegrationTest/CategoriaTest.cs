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
    public class CategoriaTest
    {
        [TestMethod]

        public async Task ObtenerTokenCategoria()
        {
            using var application = new WebApplicationFactory<Program>();
            using var usuario = application.CreateClient();

            var respuesta = await usuario.PostAsJsonAsync("api/login", new UsuarioLogin { NombreUsuario = "Francisco", Clave = "1235" });

            var token = await respuesta.Content.ReadAsStringAsync();

            Assert.IsNotNull(token);
        }

        [TestMethod]

        public async Task ObtenerCategorias()
        {
            using var application = new WebApplicationFactory<Program>();
            using var categoria = application.CreateClient();
            categoria.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRnJhbmNpc2NvIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXN1YXJpbyIsImV4cCI6MTY5OTU5Nzg2NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIzNi8iLCJhdWQiOiJsb2NhbGhvc3QifQ.-CJjeszvbsqMjrwcwwO8M5n0Bl0AW7hIVgFh8XjXxH4");

            var respuesta = await categoria.GetFromJsonAsync<List<CategoriaDTO>>("api/categorias");
            Assert.IsTrue(respuesta != null);
        }

        [TestMethod]
        public async Task ObtenerCategoriaXId()
        {
            using var application = new WebApplicationFactory<Program>();
            using var categoria = application.CreateClient();
            categoria.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRnJhbmNpc2NvIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXN1YXJpbyIsImV4cCI6MTY5OTU5Nzg2NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIzNi8iLCJhdWQiOiJsb2NhbGhvc3QifQ.-CJjeszvbsqMjrwcwwO8M5n0Bl0AW7hIVgFh8XjXxH4");

            var respuesta = await categoria.GetAsync("api/categorias/1");
            Assert.IsTrue(respuesta != null);
        }

        [TestMethod]

        public async Task GuardarCategoria()
        {
            using var application = new WebApplicationFactory<Program>();
            using var categoria = application.CreateClient();
            categoria.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRnJhbmNpc2NvIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXN1YXJpbyIsImV4cCI6MTY5OTU5Nzg2NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIzNi8iLCJhdWQiOiJsb2NhbGhvc3QifQ.-CJjeszvbsqMjrwcwwO8M5n0Bl0AW7hIVgFh8XjXxH4");


            var objecto = new CategoriaDTO { Nombre = "Perros" };
            var respuesta = await categoria.PostAsJsonAsync("api/categoria", objecto);

            //var respuesta = await cliente.PostAsJsonAsync("api/categoria", new CategoriaDTO { Nombre = "Prueva de Integracion"});

            Assert.AreEqual(HttpStatusCode.Created, respuesta.StatusCode);
        }

        [TestMethod]

        public async Task ModificarCategoria()
        {
            using var application = new WebApplicationFactory<Program>();
            using var categoria = application.CreateClient();
            categoria.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRnJhbmNpc2NvIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXN1YXJpbyIsImV4cCI6MTY5OTU5Nzg2NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIzNi8iLCJhdWQiOiJsb2NhbGhvc3QifQ.-CJjeszvbsqMjrwcwwO8M5n0Bl0AW7hIVgFh8XjXxH4");


            var objecto = new CategoriaDTO { Id = 1, Nombre = "Vaca" };
            var respuesta = await categoria.PutAsJsonAsync("api/categoria/1", objecto);

            //var respuesta = await cliente.PostAsJsonAsync("api/categoria", new CategoriaDTO { Nombre = "Prueva de Integracion"});

            Assert.AreEqual(HttpStatusCode.OK, respuesta.StatusCode);
        }

        [TestMethod]

        public async Task EliminarCategoria()
        {
            using var application = new WebApplicationFactory<Program>();
            using var categoria = application.CreateClient();
            categoria.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRnJhbmNpc2NvIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXN1YXJpbyIsImV4cCI6MTY5OTU5Nzg2NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIzNi8iLCJhdWQiOiJsb2NhbGhvc3QifQ.-CJjeszvbsqMjrwcwwO8M5n0Bl0AW7hIVgFh8XjXxH4");

            var respuesta = await categoria.DeleteAsync("api/categoria/3");

            Assert.AreEqual(HttpStatusCode.NoContent, respuesta.StatusCode);
        }
    }
}
