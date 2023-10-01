using TiendaAPI.DTOs;

namespace TiendaAPI.Respositories.Interfaces
{
    public interface IMarca
    {
        Task<int> crear(MarcaDTO marca);
        Task<ICollection<MarcaDTO>> Marcas();
        Task<MarcaDTO> Marca(int id);
        Task<int> Modificar(int id, MarcaDTO marca);
        Task<int> Eliminar(int id);
        Task<int> Guardar();
    }
}
