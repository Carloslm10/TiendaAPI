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
    public class CategoriaTest
    {
        private readonly CategoriaRepository _categoriaRepository;
        public CategoriaTest()
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

            _categoriaRepository = new CategoriaRepository(dbContext, mapper);
        }

        [Fact]
        public async void TestCrear()
        {
            //Arranque (Preparar)
            var objecto = new CategoriaDTO();
            objecto.Nombre = "Otacus";

            //Act (Actuar)
            int resultado = await _categoriaRepository.Crear(objecto);


            //Assert (Afirmmar)
            Assert.True(resultado == 1);
        }

        [Fact]
        public async void TestObtener()
        {
            //Arranque (Preparar)


            //Act (Actuar)
            var categoria = await _categoriaRepository.Categorias();


            //Assert (Afirmmar)
            //Assert.True(clientes.Count > 0);
            Assert.NotNull(categoria);
        }

        [Fact]
        public async void TestObtenerXId()
        {
            //Arranque (Preparar)
            int id = 1;

            //Act (Actuar)
            var categoria = await _categoriaRepository.Categoria(id);


            //Assert (Afirmmar)
            //Assert.True(clientes.Count > 0);
            Assert.NotNull(categoria);
        }

        [Fact]
        public async void TestModificar()
        {
            //Arranque (Preparar)
            int id = 1;
            var objecto = new CategoriaDTO();
            //objecto.Id = id;
            objecto.Nombre = "Narutosin";

            //Act (Actuar)
            var resultado = await _categoriaRepository.Modificar(id, objecto);


            //Assert (Afirmmar)
            Assert.Equal(1, resultado);
        }


        [Fact]
        public async void TestEliminar()
        {
            //Arranque (Preparar)
            int id = 2;

            //Act (Actuar)
            var resultado = await _categoriaRepository.Eliminar(id);


            //Assert (Afirmmar)
            Assert.Equal(1, resultado);
        }
    }
}
