using TiendaAPI.DTOs;
using TiendaAPI.Respositories.Interfaces;

namespace TiendaAPI.Enpoints
{
    public static class UsuarioEndpoints
    {
        public static async void Add(this WebApplication app)
        {
            //Obtener todos los registros de la tabla
            app.MapGet("api/usuarios", async (IUsuario _usuario) =>
            {
                var usuarios = await _usuario.Usuarios();

                return Results.Ok(usuarios);
            }).WithTags("Usuarios").AllowAnonymous();

            //Buscar por ID
            app.MapGet("api/usuarios/{id}", async (int id, IUsuario _usuario) =>
            {
                var usuario = await _usuario.Usuario(id);
                if(usuario == null)
                    return Results.NotFound();
                else 
                    return Results.Ok(usuario);
            }).WithTags("Usuarios").RequireAuthorization();

            //Agregar un nuevo registro
            app.MapPost("api/usuario", async (UsuarioDTO usuario, IUsuario _usuario) =>
            {
                if(usuario == null)
                    return Results.BadRequest();

                await _usuario.Crear(usuario);

                return Results.Created("api/usuarios/{usuario.Id}", usuario);
            }).WithTags("Usuarios").RequireAuthorization();

            //Modificar un registro
            app.MapPut("api/usuario/{id}", async (int id, UsuarioDTO usuario, IUsuario _usuario) =>
            {
                var resultado = await _usuario.Modificar(id, usuario);
                if(resultado == 0)
                    return Results.NotFound();
                else
                    return Results.Ok(resultado);
            }).WithTags("Usuarios").RequireAuthorization();

            //Eliminar un registro
            app.MapDelete("api/usuario/{id}", async (int id, IUsuario _usuario) =>
            {
                var resultado = await _usuario.Eliminar(id);
                if (resultado == 0)
                    return Results.NotFound();
                else
                    return Results.NoContent();
            }).WithTags("Usuarios").RequireAuthorization();

            app.MapPost("api/login", async (UsuarioLogin usuario, IUsuario _usuario) => {
                var login = await _usuario.Login(usuario);

                if (login == null)
                    return Results.NotFound(new { mensaje = "Usuario o contraseña incorecto" });

                var token = _usuario.GenerarToken(login);

                login.Clave = String.Empty;

                if (String.IsNullOrEmpty(token))
                {
                    return Results.Unauthorized();
                }
                else
                {
                    return Results.Ok(token);
                }
            }).WithTags("Usuarios");
        }
    }
}
