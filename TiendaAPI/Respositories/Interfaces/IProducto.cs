using TiendaAPI.DTOs;

namespace TiendaAPI.Respositories.Interfaces
{
    public interface IProducto
    {
        //Crear Nuevo
        Task<int> Crear(GuardarProductoDTO producto);
        //Traer los datos
        Task<ICollection<ProductoDTO>> Productos();
        //Buscar x id
        Task<ProductoDTO> Producto(int id);
        //Modificar dato
        Task<int> Modificar(int id, ProductoDTO producto);
        //Eliminar dato
        Task<int> Eliminar(int id);
        //Guardar un dato nuevo
        Task<int> Guardar();
    }
}
