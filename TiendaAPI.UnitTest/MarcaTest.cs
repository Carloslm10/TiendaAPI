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
    public class MarcaTest
    {
        private readonly MarcaRepository _marcaRepository;
        public MarcaTest()
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

            _marcaRepository = new MarcaRepository(dbContext, mapper);
        }

        [Fact]
        public async void TestCrear()
        {
            //Arranque (Preparar)
            var objecto = new MarcaDTO();
            objecto.Nombre = "Adidas Naruto";

            //Act (Actuar)
            int resultado = await _marcaRepository.Crear(objecto);


            //Assert (Afirmmar)
            Assert.True(resultado == 1);
        }

        [Fact]
        public async void TestObtener()
        {
            //Arranque (Preparar)


            //Act (Actuar)
            var marca = await _marcaRepository.Marcas();


            //Assert (Afirmmar)
            //Assert.True(clientes.Count > 0);
            Assert.NotNull(marca);
        }

        [Fact]
        public async void TestObtenerXId()
        {
            //Arranque (Preparar)
            int id = 1;

            //Act (Actuar)
            var marca = await _marcaRepository.Marca(id);


            //Assert (Afirmmar)
            //Assert.True(clientes.Count > 0);
            Assert.NotNull(marca);
        }

        [Fact]
        public async void TestModificar()
        {
            //Arranque (Preparar)
            int id = 1;
            var objecto = new MarcaDTO();
            //objecto.Id = id;
            objecto.Nombre = "Cacarotos";

            //Act (Actuar)
            var resultado = await _marcaRepository.Modificar(id, objecto);


            //Assert (Afirmmar)
            Assert.Equal(1, resultado);
        }


        [Fact]
        public async void TestEliminar()
        {
            //Arranque (Preparar)
            int id = 2;

            //Act (Actuar)
            var resultado = await _marcaRepository.Eliminar(id);


            //Assert (Afirmmar)
            Assert.Equal(1, resultado);
        }
    }
}
