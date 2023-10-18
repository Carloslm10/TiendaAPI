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
    public class VentaTest
    {
        public readonly VentaRepository _ventaRepository;
        public VentaTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer("Data Source = CRISTINA; Initial Catalog = ControlProductos; Integrated Security = True; Trust Server Certificate = True")
                 .Options;

            var dbContext = new ApplicationDbContext(options);

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingsProfiles>();
            });

            var mapper = configuration.CreateMapper();

            _ventaRepository = new VentaRepository(dbContext, mapper);
        }

        [Fact]

        public async void TestCrear()
        {
            //Arrange (preparar)
            var objecto = new GuardarVentaDTO();

            objecto.Usuario_id = 1;
            objecto.Cliente_id = 1;
            objecto.Producto_id = 1;
            objecto.Cantidad = 1;

            //Act (Actuar)
            int resultado = await _ventaRepository.Crear(objecto);

            //Assert (Afirmar)
            Assert.True(resultado == 1);
        }
    }
}