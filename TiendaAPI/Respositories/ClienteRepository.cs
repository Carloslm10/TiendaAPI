using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TiendaAPI.Context;
using TiendaAPI.DTOs;
using TiendaAPI.Entities;
using TiendaAPI.Respositories.Interfaces;

namespace TiendaAPI.Respositories
{
    public class ClienteRepository : ICliente
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ClienteRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ClienteDTO> Cliente(int id)
        {
            var entidad = await _db.Clientes.FindAsync();
            var cliente = _mapper.Map<Cliente, ClienteDTO>(entidad);

            return cliente;
        }

        public async Task<ICollection<ClienteDTO>> Clientes()
        {
            var entidades = await _db.Clientes.ToListAsync();
            var clientes = _mapper.Map<ICollection<Cliente>, ICollection<ClienteDTO>>(entidades); 
            
            return clientes;
        }

        public async Task<int> Crear(ClienteDTO cliente)
        {
            await _db.Clientes.AddAsync(_mapper.Map<ClienteDTO, Cliente>(cliente));
            
            return await Guardar();
        }

        public async Task<int> Eliminar(int id)
        {
            var cliente = await _db.Clientes.FindAsync(id);
            if(cliente == null)
                return 0;
            _db.Clientes.Remove(cliente);
            
            return await Guardar();
        }

        public async Task<int> Guardar()
        {
            return await _db.SaveChangesAsync();
        }

        public async Task<int> Modificar(int id, ClienteDTO cliente)
        {
            var entidad = await _db.Clientes.FindAsync(id);
            if (entidad == null)
                return 0;

            entidad.Nombre = cliente.Nombre;
            entidad.Apellido = cliente.Apellido;
            entidad.Dui = cliente.Dui;
            entidad.Direccion = cliente.Direccion;
            entidad.Telefono = cliente.Telefono;
            _db.Clientes.Update(entidad);

            return await Guardar();
        }
    }
}
