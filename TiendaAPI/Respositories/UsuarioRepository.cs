using AutoMapper;
using TiendaAPI.Context;
using TiendaAPI.DTOs;
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

        public Task<UsuarioDTO> Usuario(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<UsuarioDTO>> Usuarios()
        {
            throw new NotImplementedException();
        }
    }
}
