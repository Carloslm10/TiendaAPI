using TiendaAPI.DTOs;

namespace TiendaAPI.Respositories.Interfaces
{
    public interface IVenta
    {
        Task<int> Crear(VentaDTO venta);
        Task<ICollection<VentaDTO>> Ventas();
        Task<VentaDTO> Venta(int id);
        Task<int> Modificar(int id, VentaDTO venta);
        Task<int> Eliminar(int id);
        Task<int> Guardar();
    }
}
