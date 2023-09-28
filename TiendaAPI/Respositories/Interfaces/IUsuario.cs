using TiendaAPI.DTOs;

namespace TiendaAPI.Respositories.Interfaces
{
    public interface IUsuario
    {
        //Crear Nuevo
        Task<int> Crear(UsuarioDTO usuario);
        //Traer los datos
        Task<ICollection<UsuarioDTO>> Usuarios();
        //Buscar x id
        Task<UsuarioDTO> Usuario(int id);
        //Modificar dato
        Task<int> Modificar(int id, UsuarioDTO usuario);
        //Eliminar dato
        Task<int> Eliminar(int id);
        //Guardar un dato nuevo
        Task<int> Guardar();
    }
}
