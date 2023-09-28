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
            CreateMap<Producto, ProductoDTO>();

            //DTO a Entidad
            CreateMap<ClienteDTO, Cliente>();
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<VentaDTO, Venta>();
            CreateMap<ProductoDTO, Producto>();
        }
    }
}
