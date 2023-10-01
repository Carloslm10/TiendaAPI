using TiendaAPI.DTOs;
using TiendaAPI.Respositories.Interfaces;

namespace TiendaAPI.Enpoints
{
    public static class VentaEndpoints
    {
        public static async void Add(this WebApplication app)
        {
            app.MapGet("api/ventas", async (IVenta _venta) => {
                var venta = await _venta.Ventas();
                //codigo 200 es Ok - Significa la sulicitud se realizo correctamente
                //y se debuelve una lista
                return Results.Ok(venta);
            }).WithTags("Ventas").AllowAnonymous();

            app.MapGet("api/ventas/{id}", async (int id, IVenta _venta) => {
                var venta = await _venta.Venta(id);
                if (venta == null)
                    //codigo 404 Not Found - El recurso solicitado no existe
                    return Results.NotFound();
                else
                    //codigo 200 es Ok - Significa la sulicitud se realizo correctamente
                    return Results.Ok(venta);
            }).WithTags("Ventas").RequireAuthorization();

            app.MapPost("api/venta", async (GuardarVentaDTO venta, IVenta _venta) => {
                if (venta == null)
                    //codigo 400 Bad Request = La solisitud no se pudo
                    //porque bienen nulos
                    return Results.BadRequest();

                await _venta.Crear(venta);
                //201 Created El recurso se creo con exito y se devuelve la ubicacion del
                //recurso creado
                return Results.Created("api/ventas/{venta.Id}", venta);
            }).WithTags("Ventas").RequireAuthorization();

            app.MapPut("api/venta/{id}", async (int id, VentaDTO venta, IVenta _venta) =>
            {
                var resultado = await _venta.Modificar(id, venta);
                if (resultado == 0)
                    return Results.NotFound();
                else
                    return Results.Ok(resultado);
            }).WithTags("Ventas").RequireAuthorization();

            app.MapDelete("api/venta/{id}", async (int id, IVenta _venta) =>
            {
                var resultado = await _venta.Eliminar(id);
                if (resultado == 0)
                    return Results.NotFound();
                else
                    return Results.NoContent(); //codigo 204 No Content - Recurso eliminado
            }).WithTags("Ventas").RequireAuthorization();
        }
    }
}
