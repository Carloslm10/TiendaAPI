using TiendaAPI.DTOs;
using TiendaAPI.Respositories.Interfaces;

namespace TiendaAPI.Enpoints
{
    public static class CategoriaEndpoints
    {
        public static async void Add(this WebApplication app)
        {
            app.MapGet("api/categorias", async (ICategoria _categoria) =>
            {
                var categorias = await _categoria.Categorias();
                //200 OK  La solicitud se realizo correctamente
                //y se devuelve una lista
                return Results.Ok(categorias);
            }).WithTags("Categorias").AllowAnonymous();

            app.MapGet("api/categorias/{id}", async (int id, ICategoria _categoria) =>
            {
                var categoria = await _categoria.Categoria(id);
                if (categoria == null)
                    return Results.NotFound();
                else
                    return Results.Ok(categoria);
            }).WithTags("Categorias").AllowAnonymous();

            app.MapPost("api/categoria", async (CategoriaDTO categoria, ICategoria _categoria) =>
            {
                if (categoria == null)
                    return Results.BadRequest();
                await _categoria.crear(categoria);

                return Results.Created("api/categorias/{categoria.id}", categoria);
            }).WithTags("Categorias").AllowAnonymous();

            app.MapPut("api/categoria/{id}", async (int id, CategoriaDTO categoria, ICategoria _categoria) =>
            {
                var resultado = await _categoria.Modificar(id, categoria);
                if (resultado == 0)
                    return Results.NotFound();
                else
                    return Results.Ok(resultado);
            }).WithTags("Categorias").AllowAnonymous();

            app.MapDelete("api/categoria/{id}", async (int id, ICategoria _categoria) => {
                var resultado = await _categoria.Eliminar(id);
                if (resultado == 0)
                    return Results.NotFound();
                else
                    return Results.NoContent();
            }).WithTags("Categorias").AllowAnonymous();

        }
    }
}
