using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TiendaAPI.DTOs;
using TiendaAPI.Entities;

namespace TiendaAPI.IntegrationTest
{
    [TestClass]
    public class ProductoTest
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

        public async Task ObtenerProductos()
        {
            using var application = new WebApplicationFactory<Program>();
            using var producto = application.CreateClient();
            producto.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRnJhbmNpc2NvIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXN1YXJpbyIsImV4cCI6MTY5OTU5Nzg2NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIzNi8iLCJhdWQiOiJsb2NhbGhvc3QifQ.-CJjeszvbsqMjrwcwwO8M5n0Bl0AW7hIVgFh8XjXxH4");

            var respuesta = await producto.GetFromJsonAsync<List<ProductoDTO>>("api/productos");
            Assert.IsTrue(respuesta != null);
        }

        [TestMethod]
        public async Task ObtenerProductoXId()
        {
            using var application = new WebApplicationFactory<Program>();
            using var producto = application.CreateClient();
            producto.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRnJhbmNpc2NvIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXN1YXJpbyIsImV4cCI6MTY5OTU5Nzg2NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIzNi8iLCJhdWQiOiJsb2NhbGhvc3QifQ.-CJjeszvbsqMjrwcwwO8M5n0Bl0AW7hIVgFh8XjXxH4");

            var respuesta = await producto.GetAsync("api/productos/2002");
            Assert.IsTrue(respuesta != null);
        }

        [TestMethod]

        public async Task GuardarProducto()
        {
            using var application = new WebApplicationFactory<Program>();
            using var producto = application.CreateClient();
            producto.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRnJhbmNpc2NvIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXN1YXJpbyIsImV4cCI6MTY5OTU5Nzg2NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIzNi8iLCJhdWQiOiJsb2NhbGhvc3QifQ.-CJjeszvbsqMjrwcwwO8M5n0Bl0AW7hIVgFh8XjXxH4");


            var objecto = new GuardarProductoDTO { Nombre = "Nike Air 180", Descripcion = "Deportivos", Precio = 250, Existencia = 100, Marca_id = 1, Categoria_id = 2 };
            var respuesta = await producto.PostAsJsonAsync("api/producto", objecto);

            //var respuesta = await cliente.PostAsJsonAsync("api/categoria", new CategoriaDTO { Nombre = "Prueva de Integracion"});

            Assert.AreEqual(HttpStatusCode.Created, respuesta.StatusCode);
        }

        [TestMethod]

        public async Task ModificarProducto()
        {
            using var application = new WebApplicationFactory<Program>();
            using var producto = application.CreateClient();
            producto.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRnJhbmNpc2NvIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXN1YXJpbyIsImV4cCI6MTY5OTU5Nzg2NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIzNi8iLCJhdWQiOiJsb2NhbGhvc3QifQ.-CJjeszvbsqMjrwcwwO8M5n0Bl0AW7hIVgFh8XjXxH4");


            var objecto = new ProductoDTO {Id = 2002, Nombre = "Adidas", Descripcion = "Comodos con conford", Precio = 290, Existencia = 50, Marca_id = 2, Categoria_id = 2 };
            var respuesta = await producto.PutAsJsonAsync("api/producto/2002", objecto);

            //var respuesta = await cliente.PostAsJsonAsync("api/categoria", new CategoriaDTO { Nombre = "Prueva de Integracion"});

            Assert.AreEqual(HttpStatusCode.OK, respuesta.StatusCode);
        }

        [TestMethod]

        public async Task EliminarProducto()
        {
            using var application = new WebApplicationFactory<Program>();
            using var producto = application.CreateClient();
            producto.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRnJhbmNpc2NvIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXN1YXJpbyIsImV4cCI6MTY5OTU5Nzg2NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIzNi8iLCJhdWQiOiJsb2NhbGhvc3QifQ.-CJjeszvbsqMjrwcwwO8M5n0Bl0AW7hIVgFh8XjXxH4");

            var respuesta = await producto.DeleteAsync("api/producto/2007");

            Assert.AreEqual(HttpStatusCode.NoContent, respuesta.StatusCode);
        }
    }
}
