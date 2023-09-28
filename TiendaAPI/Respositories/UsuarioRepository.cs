using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TiendaAPI.Context;
using TiendaAPI.DTOs;
using TiendaAPI.Entities;
using TiendaAPI.Respositories.Interfaces;

namespace TiendaAPI.Respositories
{
    public class UsuarioRepository : IUsuario
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public UsuarioRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public Task<int> Crear(UsuarioDTO usuario)
        {
            throw new NotImplementedException();
        }

        public Task<int> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Guardar()
        {
            return await _db.SaveChangesAsync();
        }

        public async Task<int> Modificar(int id, UsuarioDTO usuario)
        {
            var entidad = await _db.Usuarios.FindAsync(id);
            if (entidad == null)
                return 0;

            entidad.NombreUsuario = usuario.NombreUsuario;
            entidad.Clave = usuario.Clave;
            entidad.Rol = usuario.Rol;
            _db.Usuarios.Update(entidad);

            return await Guardar();
        }

        public async Task<UsuarioDTO> Usuario(int id)
        {
            var entidad = await _db.Usuarios.ToListAsync();
            var usuario = _mapper.Map<Usuario, UsuarioDTO>(entidad);

            return usuario;
        }

        public async Task<ICollection<UsuarioDTO>> Usuarios()
        {
            var entidades = await _db.Usuarios.ToListAsync();
            var usuarios = _mapper.Map<ICollection<Usuario>, ICollection<UsuarioDTO>>(entidades);

            return usuarios;
        }
    }
}
