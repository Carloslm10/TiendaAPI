using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaAPI.Context;
using TiendaAPI.DTOs;
using TiendaAPI.Mappings;
using TiendaAPI.Respositories;

namespace TiendaAPI.UnitTest
{
    public class ProductoTest
    {
        private readonly ProductoRepository _productoRepository;
        public ProductoTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("server=LAPTOP-QV3Q6T02;Database=Tienda_Zapatos;user id=sa;Password=carlos12358;Encrypt=False; TrustServerCertificate=False;")
                .Options;

            var dbContext = new ApplicationDbContext(options);

            var configurations = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingsProfiles>();
            });

            var mapper = configurations.CreateMapper();

            _productoRepository = new ProductoRepository(dbContext, mapper);
        }

        [Fact]
        public async void TestCrear()
        {
            //Arranque (Preparar)
            var objecto = new GuardarProductoDTO();
            objecto.Nombre = "Adidas";
            objecto.Descripcion = "Comodos";
            objecto.Precio = 120;
            objecto.Existencia = 50;
            objecto.Marca_id = 1;
            objecto.Categoria_id = 2;

            //Act (Actuar)
            int resultado = await _productoRepository.Crear(objecto);


            //Assert (Afirmmar)
            Assert.True(resultado == 1);
        }

        [Fact]
        public async void TestObtener()
        {
            //Arranque (Preparar)


            //Act (Actuar)
            var productos = await _productoRepository.Productos();


            //Assert (Afirmmar)
            //Assert.True(clientes.Count > 0);
            Assert.NotNull(productos);
        }

        [Fact]
        public async void TestObtenerXId()
        {
            //Arranque (Preparar)
            int id = 1;

            //Act (Actuar)
            var producto = await _productoRepository.Producto(id);


            //Assert (Afirmmar)
            //Assert.True(clientes.Count > 0);
            Assert.NotNull(producto);
        }

        [Fact]
        public async void TestModificar()
        {
            //Arranque (Preparar)
            int id = 1;
            var objecto = new ProductoDTO();
            //objecto.Id = id;
            objecto.Nombre = "Air Max 50";
            objecto.Descripcion = "Comodos";
            objecto.Precio = 110;
            objecto.Existencia = 20;
            objecto.Marca_id = 2;
            objecto.Categoria_id = 1;

            //Act (Actuar)
            var resultado = await _productoRepository.Modificar(id, objecto);


            //Assert (Afirmmar)
            Assert.Equal(1, resultado);
        }


        [Fact]
        public async void TestEliminar()
        {
            //Arranque (Preparar)
            int id = 1;

            //Act (Actuar)
            var resultado = await _productoRepository.Eliminar(id);


            //Assert (Afirmmar)
            Assert.Equal(1, resultado);
        }
    }
}
