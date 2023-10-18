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
using TiendaAPI.Settings;

namespace TiendaAPI.UnitTest
{
    public class UsuarioTest
    {
        //private readonly UsuarioRepository _usuarioRepository;
        //public UsuarioTest()
        //{
        //    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        //        .UseSqlServer("server=LAPTOP-QV3Q6T02;Database=ControlProductos;user id=sa;Password=carlos12358;Encrypt=False; TrustServerCertificate=False;")
        //        .Options;

        //    var dbContext = new ApplicationDbContext(options);

        //    var configurations = new MapperConfiguration(cfg => {
        //        cfg.AddProfile<MappingsProfiles>();
        //    });

        //    var mapper = configurations.CreateMapper();

        //    _usuarioRepository = new UsuarioRepository(dbContext, mapper);
        //}

        //[Fact]
        //public async void TestCrear()
        //{
        //    //Arranque (Preparar)
        //    var objecto = new UsuarioDTO();
        //    objecto.NombreUsuario = "Jamon";
        //    objecto.Clave = "123";
        //    objecto.Rol = "Administrador";

        //    //Act (Actuar)
        //    int resultado = await _usuarioRepository.Crear(objecto);


        //    //Assert (Afirmmar)
        //    Assert.True(resultado == 1);
        //}

        //[Fact]
        //public async void TestObtener()
        //{
        //    //Arranque (Preparar)


        //    //Act (Actuar)
        //    var clientes = await _usuarioRepository.Usuarios();


        //    //Assert (Afirmmar)
        //    //Assert.True(clientes.Count > 0);
        //    Assert.NotNull(clientes);
        //}

        //[Fact]
        //public async void TestObtenerXId()
        //{
        //    //Arranque (Preparar)
        //    int id = 1;

        //    //Act (Actuar)
        //    var usuario = await _usuarioRepository.Usuario(id);


        //    //Assert (Afirmmar)
        //    //Assert.True(clientes.Count > 0);
        //    Assert.NotNull(usuario);
        //}

        //[Fact]
        //public async void TestModificar()
        //{
        //    //Arranque (Preparar)
        //    int id = 1;
        //    var objecto = new UsuarioDTO();
        //    //objecto.Id = id;
        //    objecto.NombreUsuario = "Mario";
        //    objecto.Clave = "1235";
        //    objecto.Rol = "Administrador";


        //    //Act (Actuar)
        //    var resultado = await _usuarioRepository.Modificar(id, objecto);


        //    //Assert (Afirmmar)
        //    Assert.Equal(1, resultado);
        //}


        //[Fact]
        //public async void TestEliminar()
        //{
        //    //Arranque (Preparar)
        //    int id = 1;

        //    //Act (Actuar)
        //    var resultado = await _usuarioRepository.Eliminar(id);


        //    //Assert (Afirmmar)
        //    Assert.Equal(1, resultado);
        //}
    }
}
