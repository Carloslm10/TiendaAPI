using AutoMapper;
using TiendaAPI.DTOs;
using TiendaAPI.Entities;


namespace TiendaAPI.Mappings
{
    public class MappingsProfiles
    {
        public MappingsProfiles() {

            //Entidad a DTO
            CreateMap<Cliente, ClienteDTO>();


            //DTO a Entidad
            CreateMap<ClienteDTO, Cliente>();
        }
    }
}
