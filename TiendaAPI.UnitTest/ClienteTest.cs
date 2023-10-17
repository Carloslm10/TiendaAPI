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
    public class ClienteTest
    {
        private readonly ClienteRepository _clienteRepository;
        public ClienteTest()
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

            _clienteRepository = new ClienteRepository(dbContext, mapper);
        }

        [Fact]
        public async void TestCrear()
        {
            //Arranque (Preparar)
            var objecto = new ClienteDTO();
            objecto.Nombre = "Juan";
            objecto.Apellido = "Perez";
            objecto.Dui = "55681565-5";
            objecto.Direccion = "Izalco";
            objecto.Telefono = "4123-5891";

            //Act (Actuar)
            int resultado = await _clienteRepository.Crear(objecto);


            //Assert (Afirmmar)
            Assert.True(resultado == 1);
        }

        [Fact]
        public async void TestObtener()
        {
            //Arranque (Preparar)


            //Act (Actuar)
            var clientes = await _clienteRepository.Clientes();


            //Assert (Afirmmar)
            //Assert.True(clientes.Count > 0);
            Assert.NotNull(clientes);
        }

        [Fact]
        public async void TestObtenerXId()
        {
            //Arranque (Preparar)
            int id = 1;

            //Act (Actuar)
            var clientes = await _clienteRepository.Cliente(id);


            //Assert (Afirmmar)
            //Assert.True(clientes.Count > 0);
            Assert.NotNull(clientes);
        }

        [Fact]
        public async void TestModificar()
        {
            //Arranque (Preparar)
            int id = 1;
            var objecto = new ClienteDTO();
            //objecto.Id = id;
            objecto.Nombre = "Juan";
            objecto.Apellido = "Gomex";
            objecto.Dui = "55681565-5";
            objecto.Direccion = "Ataco";
            objecto.Telefono = "4123-5891";

            //Act (Actuar)
            var resultado = await _clienteRepository.Modificar(id, objecto);


            //Assert (Afirmmar)
            Assert.Equal(1, resultado);
        }


        [Fact]
        public async void TestEliminar()
        {
            //Arranque (Preparar)
            int id = 1;

            //Act (Actuar)
            var resultado = await _clienteRepository.Eliminar(id);


            //Assert (Afirmmar)
            Assert.Equal(1, resultado);
        }
    }
}
