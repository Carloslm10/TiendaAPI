﻿using AutoMapper;
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
    public class VentaTest
    {
        private readonly VentaRepository _ventaRepository;
        public VentaTest()
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

            _ventaRepository = new VentaRepository(dbContext, mapper);
        }

        [Fact]
        public async void TestCrear()
        {
            //Arrange (preparar)
            var objecto = new GuardarVentaDTO();
            objecto.Usuario_id = 1;
            objecto.Cliente_id = 1002;
            objecto.Producto_id = 2005;
            objecto.Cantidad = 1032;
            objecto.Fecha = DateTime.Now;

            //Act (Actuar)
            int resultado = await _ventaRepository.Crear(objecto);

            //Assert (Afirmar)
            Assert.True(resultado == 1);
        }

        [Fact]
        public async void TestObtener()
        {
            //Arranque (Preparar)


            //Act (Actuar)
            var ventas = await _ventaRepository.Ventas();


            //Assert (Afirmmar)
            //Assert.True(clientes.Count > 0);
            Assert.NotNull(ventas);
        }

        [Fact]
        public async void TestObtenerXId()
        {
            //Arranque (Preparar)
            int id = 2;

            //Act (Actuar)
            var venta = await _ventaRepository.Venta(id);


            //Assert (Afirmmar)
            //Assert.True(clientes.Count > 0);
            Assert.NotNull(venta);
        }

        [Fact]
        public async void TestModificar()
        {
            //Arranque (Preparar)
            int id = 1004;
            var objecto = new VentaDTO();
            //objecto.Id = id;
            objecto.Usuario_id = 1;
            objecto.Cliente_id = 1002;
            objecto.Producto_id = 2005;
            objecto.Cantidad = 8950;
            objecto.Fecha = DateTime.Now;

            //Act (Actuar)
            var resultado = await _ventaRepository.Modificar(id, objecto);


            //Assert (Afirmmar)
            Assert.Equal(1, resultado);
        }


        [Fact]
        public async void TestEliminar()
        {
            //Arranque (Preparar)
            int id = 1010;

            //Act (Actuar)
            var resultado = await _ventaRepository.Eliminar(id);


            //Assert (Afirmmar)
            Assert.Equal(1, resultado);
        }
    }
}