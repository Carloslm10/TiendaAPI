using TiendaAPI.DTOs;

namespace TiendaAPI.Respositories.Interfaces
{
    public interface ICliente
    {
        //Crear Nuevo
        Task<int> Crear(ClienteDTO cliente);
        //Traer los datos
        Task<ICollection<ClienteDTO>> Clientes();
        //Buscar x id
        Task<ClienteDTO> Cliente(int id);
        //Modificar dato
        Task<int> Modificar(int id, ClienteDTO cliente);
        //Eliminar dato
        Task<int> Eliminar(int id);
        //Guardar un dato nuevo
        Task<int> Guardar();
    }
}
