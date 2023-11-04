﻿using Microsoft.AspNetCore.Mvc.Testing;
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
    public class MarcaTest
    {
        [TestMethod]

        public async Task ObtenerTokenMarca()
        {
            using var application = new WebApplicationFactory<Program>();
            using var usuario = application.CreateClient();

            var respuesta = await usuario.PostAsJsonAsync("api/login", new UsuarioLogin { NombreUsuario = "Francisco", Clave = "1235" });

            var token = await respuesta.Content.ReadAsStringAsync();

            Assert.IsNotNull(token);
        }

        [TestMethod]

        public async Task ObtenerMarcas()
        {
            using var application = new WebApplicationFactory<Program>();
            using var marca = application.CreateClient();
            marca.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRnJhbmNpc2NvIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXN1YXJpbyIsImV4cCI6MTY5OTU5Nzg2NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIzNi8iLCJhdWQiOiJsb2NhbGhvc3QifQ.-CJjeszvbsqMjrwcwwO8M5n0Bl0AW7hIVgFh8XjXxH4");

            var respuesta = await marca.GetFromJsonAsync<List<MarcaDTO>>("api/marcas");
            Assert.IsTrue(respuesta != null);
        }

        [TestMethod]
        public async Task ObtenerMarcaXId()
        {
            using var application = new WebApplicationFactory<Program>();
            using var marca = application.CreateClient();
            marca.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRnJhbmNpc2NvIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXN1YXJpbyIsImV4cCI6MTY5OTU5Nzg2NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIzNi8iLCJhdWQiOiJsb2NhbGhvc3QifQ.-CJjeszvbsqMjrwcwwO8M5n0Bl0AW7hIVgFh8XjXxH4");

            var respuesta = await marca.GetAsync("api/marcas/2");
            Assert.IsTrue(respuesta != null);
        }

        [TestMethod]

        public async Task GuardarMarca()
        {
            using var application = new WebApplicationFactory<Program>();
            using var marca = application.CreateClient();
            marca.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRnJhbmNpc2NvIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXN1YXJpbyIsImV4cCI6MTY5OTU5Nzg2NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIzNi8iLCJhdWQiOiJsb2NhbGhvc3QifQ.-CJjeszvbsqMjrwcwwO8M5n0Bl0AW7hIVgFh8XjXxH4");


            var objecto = new MarcaDTO { Nombre = "Sapos"};
            var respuesta = await marca.PostAsJsonAsync("api/marca", objecto);

            //var respuesta = await cliente.PostAsJsonAsync("api/categoria", new CategoriaDTO { Nombre = "Prueva de Integracion"});

            Assert.AreEqual(HttpStatusCode.Created, respuesta.StatusCode);
        }

        [TestMethod]

        public async Task ModificarMarca()
        {
            using var application = new WebApplicationFactory<Program>();
            using var marca = application.CreateClient();
            marca.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRnJhbmNpc2NvIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXN1YXJpbyIsImV4cCI6MTY5OTU5Nzg2NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIzNi8iLCJhdWQiOiJsb2NhbGhvc3QifQ.-CJjeszvbsqMjrwcwwO8M5n0Bl0AW7hIVgFh8XjXxH4");


            var objecto = new MarcaDTO { Id = 1, Nombre = "Burros" };
            var respuesta = await marca.PutAsJsonAsync("api/marca/1", objecto);

            //var respuesta = await cliente.PostAsJsonAsync("api/categoria", new CategoriaDTO { Nombre = "Prueva de Integracion"});

            Assert.AreEqual(HttpStatusCode.OK, respuesta.StatusCode);
        }

        [TestMethod]

        public async Task EliminarMarca()
        {
            using var application = new WebApplicationFactory<Program>();
            using var marca = application.CreateClient();
            marca.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRnJhbmNpc2NvIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXN1YXJpbyIsImV4cCI6MTY5OTU5Nzg2NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIzNi8iLCJhdWQiOiJsb2NhbGhvc3QifQ.-CJjeszvbsqMjrwcwwO8M5n0Bl0AW7hIVgFh8XjXxH4");

            var respuesta = await marca.DeleteAsync("api/marca/3");

            Assert.AreEqual(HttpStatusCode.NoContent, respuesta.StatusCode);
        }
    }
}
