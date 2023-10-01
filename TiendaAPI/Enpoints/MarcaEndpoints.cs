using TiendaAPI.DTOs;
using TiendaAPI.Respositories.Interfaces;

namespace TiendaAPI.Enpoints
{
    public static class MarcaEndpoints
    {
        public static void Add(this WebApplication app)
        {
            app.MapGet("api/marcas", async (IMarca _marca) =>
            {
                var marcas = await _marca.Marcas();
                return Results.Ok(marcas);
            }).WithTags("Marcas").AllowAnonymous();

            app.MapGet("api/marcas/{id}", async (int id, IMarca _marca) =>
            {
                var marca = await _marca.Marca(id);
                if (marca == null)
                    return Results.NotFound();
                else
                    return Results.Ok(marca);
            }).WithTags("Marcas").RequireAuthorization();

            app.MapPost("api/marca", async (MarcaDTO marca, IMarca _marca) =>
            {
                if (marca == null)
                    return Results.BadRequest();
                await _marca.crear(marca);

                return Results.Created("api/marcas/{marca.id}", marca);
            }).WithTags("Marcas").RequireAuthorization();

            app.MapPut("api/marca/{id}", async (int id, MarcaDTO marca, IMarca _marca) =>
            {
                var resultado = await _marca.Modificar(id, marca);
                if (resultado == 0)
                    return Results.NotFound();
                else
                    return Results.Ok(resultado);
            }).WithTags("Marcas").RequireAuthorization();

            app.MapDelete("api/marca/{id}", async (int id, IMarca _marca) => {
                var resultado = await _marca.Eliminar(id);
                if (resultado == 0)
                    return Results.NotFound();
                else
                    return Results.NoContent();
            }).WithTags("Marcas").RequireAuthorization();
        }
    }
}
