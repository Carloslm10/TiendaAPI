using AutoMapper;
using TiendaAPI.DTOs;
using TiendaAPI.Entities;


namespace TiendaAPI.Mappings
{
    public class MappingsProfiles : Profile
    {
        public MappingsProfiles() {

            //Entidad a DTO
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<Venta, VentaDTO>();
            CreateMap<Venta, GuardarVentaDTO>();
            CreateMap<Producto, ProductoDTO>();
            CreateMap<Producto, GuardarProductoDTO>();
            CreateMap<Marca, MarcaDTO>();
            CreateMap<Categoria, CategoriaDTO>();

            //DTO a Entidad
            CreateMap<ClienteDTO, Cliente>();
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<VentaDTO, Venta>();
            CreateMap<GuardarVentaDTO, Venta>();
            CreateMap<ProductoDTO, Producto>();
            CreateMap<GuardarProductoDTO, Producto>();
            CreateMap<MarcaDTO, Marca>();
            CreateMap<CategoriaDTO, Categoria>();
        }
    }
}
