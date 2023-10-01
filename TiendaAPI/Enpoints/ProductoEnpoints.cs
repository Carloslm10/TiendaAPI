using TiendaAPI.DTOs;
using TiendaAPI.Respositories.Interfaces;

namespace TiendaAPI.Enpoints
{
    public static class ProductoEnpoints
    {
        public static async void Add(this WebApplication app)
        {
            app.MapGet("api/productos", async (IProducto _producto) => {
                var producto = await _producto.Productos();
                //codigo 200 es Ok - Significa la sulicitud se realizo correctamente
                //y se debuelve una lista
                return Results.Ok(producto);
            }).WithTags("Productos").AllowAnonymous();

            app.MapGet("api/productos/{id}", async (int id, IProducto _producto) =>
            {
                var producto = await _producto.Producto(id);
                if (producto == null)
                    //codigo 404 Not Found - El recurso solicitado no existe
                    return Results.NotFound();
                else
                    //codigo 200 es Ok - Significa la sulicitud se realizo correctamente
                    return Results.Ok(producto);
            }).WithTags("Productos").RequireAuthorization();

             app.MapPost("api/producto", async (GuardarProductoDTO producto, IProducto _producto) => {
                 if (producto == null)
                     //codigo 400 Bad Request = La solisitud no se pudo
                     //porque bienen nulos
                     return Results.BadRequest();

                 await _producto.Crear(producto);
                 //201 Created El recurso se creo con exito y se devuelve la ubicacion del
                 //recurso creado
                 return Results.Created("api/productos/{producto.Id}", producto);
             }).WithTags("Productos").RequireAuthorization();

            app.MapPut("api/producto/{id}", async (int id, ProductoDTO producto, IProducto _producto) =>
            {
                var resultado = await _producto.Modificar(id, producto);
                if (resultado == 0)
                    return Results.NotFound();
                else
                    return Results.Ok(resultado);
            }).WithTags("Productos").RequireAuthorization();

            app.MapDelete("api/producto/{id}", async (int id, IProducto _producto) =>
            {
                var resultado = await _producto.Eliminar(id);
                if (resultado == 0)
                    return Results.NotFound();
                else
                    return Results.NoContent(); //codigo 204 No Content - Recurso eliminado
            }).WithTags("Productos").RequireAuthorization();
        }
    }
}
