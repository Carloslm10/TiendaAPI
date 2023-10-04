using TiendaAPI.DTOs;
using TiendaAPI.Respositories.Interfaces;

namespace TiendaAPI.Enpoints
{
    public static class ClienteEndpoints
    {
        public static async void Add(this WebApplication app)
        {
            app.MapGet("api/clientes", async (ICliente _cliente) => {
                var cliente = await _cliente.Clientes();
                //codigo 200 es Ok - Significa la sulicitud se realizo correctamente
                //y se debuelve una lista
                return Results.Ok(cliente);
            }).WithTags("Clientes").AllowAnonymous();

            app.MapGet("api/clientes/{id}", async (int id, ICliente _cliente) => {
                var cliente = await _cliente.Cliente(id);
                if (cliente == null)
                    //codigo 404 Not Found - El recurso solicitado no existe
                    return Results.NotFound("No se encontro el Cliente: " + id);
                else
                    //codigo 200 es Ok - Significa la sulicitud se realizo correctamente
                    return Results.Ok(cliente);
            }).WithTags("Clientes").RequireAuthorization();

            app.MapPost("api/cliente", async(ClienteDTO cliente, ICliente _cliente) => {
                if (cliente == null)
                    //codigo 400 Bad Request = La solisitud no se pudo
                    //porque bienen nulos
                    return Results.BadRequest();

                await _cliente.Crear(cliente);
                //201 Created El recurso se creo con exito y se devuelve la ubicacion del
                //recurso creado
                return Results.Created("api/clientes/{cliente.Id}", cliente);
            }).WithTags("Clientes").RequireAuthorization();

            app.MapPut("api/cliente/{id}", async (int id, ClienteDTO cliente, ICliente _cliente) =>
            {
                var resultado = await _cliente.Modificar(id, cliente);
                if(resultado == 0)
                    return Results.NotFound();
                else
                    return Results.Ok(resultado);
            }).WithTags("Clientes").RequireAuthorization();

            app.MapDelete("api/cliente/{id}", async (int id, ICliente _cliente) =>
            {
                var resultado = await _cliente.Eliminar(id);
                if(resultado == 0)
                    return Results.NotFound();
                else
                    return Results.NoContent(); //codigo 204 No Content - Recurso eliminado
            }).WithTags("Clientes").RequireAuthorization();
        }
    }
}
