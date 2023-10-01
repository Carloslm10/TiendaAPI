using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TiendaAPI.Context;
using TiendaAPI.DTOs;
using TiendaAPI.Entities;
using TiendaAPI.Respositories.Interfaces;

namespace TiendaAPI.Respositories
{
    public class MarcaRepository : IMarca
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public MarcaRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> crear(MarcaDTO marca)
        {
            await _db.Marcas.AddAsync(_mapper.Map<MarcaDTO, Marca>(marca));
            return await Guardar();
        }

        public async Task<int> Eliminar(int id)
        {
            var marca = await _db.Marcas.FindAsync(id);
            if (marca == null)
                return 0;

            _db.Marcas.Remove(marca);
            return await Guardar();
        }

        public async Task<int> Guardar()
        {
            return await _db.SaveChangesAsync();
        }

        public async Task<MarcaDTO> Marca(int id)
        {
            var entidad = await _db.Marcas.FindAsync(id);
            var marca = _mapper.Map<Marca, MarcaDTO>(entidad);

            return marca;
        }

        public async Task<ICollection<MarcaDTO>> Marcas()
        {
            var entidades = await _db.Marcas.ToListAsync();
            var marcas = _mapper.Map<ICollection<Marca>, ICollection<MarcaDTO>>(entidades);

            return marcas;
        }

        public async Task<int> Modificar(int id, MarcaDTO marca)
        {
            var entidad = await _db.Marcas.FindAsync(id);
            if (entidad == null)
                return 0;

            entidad.Nombre = marca.Nombre;
            _db.Marcas.Update(entidad);

            return await Guardar();
        }
    }
}
