using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TiendaAPI.Context;
using TiendaAPI.DTOs;
using TiendaAPI.Entities;
using TiendaAPI.Respositories.Interfaces;
using TiendaAPI.Settings;

namespace TiendaAPI.Respositories
{
    public class UsuarioRepository : IUsuario
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly TokenSetting _tokenSetting;

        public UsuarioRepository(ApplicationDbContext db, IMapper mapper, IOptions<TokenSetting> tokenSetting)
        {
            _db = db;
            _mapper = mapper;
            _tokenSetting = tokenSetting.Value;
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
            var entidad = await _db.Usuarios.FindAsync(id);
            var usuario = _mapper.Map<Usuario, UsuarioDTO>(entidad);

            return usuario;
        }

        public async Task<ICollection<UsuarioDTO>> Usuarios()
        {
            var entidades = await _db.Usuarios.ToListAsync();
            var usuarios = _mapper.Map<ICollection<Usuario>, ICollection<UsuarioDTO>>(entidades);

            return usuarios;
        }

        public string GenerarToken(UsuarioDTO usuario)
        {
            var claveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSetting.Key));
            var credenciales = new SigningCredentials(claveSimetrica, SecurityAlgorithms.HmacSha256);
            var claimsUsuarios = new List<Claim>
            {
                new Claim("id", usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.NombreUsuario),
                new Claim(ClaimTypes.Role, usuario.Rol),
            };

            var jwt = new JwtSecurityToken(
                issuer: _tokenSetting.Issuer,
                audience: _tokenSetting.Audience,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credenciales,
                claims: claimsUsuarios
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public async Task<UsuarioDTO> Login(UsuarioLogin login)
        {
            var entidad = await _db.Usuarios
                .FirstOrDefaultAsync(x => x.NombreUsuario == login.NombreUsuario && x.Clave == login.Clave);
            var usuario = _mapper.Map<Usuario, UsuarioDTO>(entidad);

            return usuario;
        }
    }
}
