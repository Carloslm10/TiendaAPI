using AutoMapper;
using TiendaAPI.Context;
using TiendaAPI.DTOs;
using TiendaAPI.Respositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using TiendaAPI.Entities;

namespace TiendaAPI.Respositories
{
    public class VentaRepository : IVenta
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public VentaRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> Crear(VentaDTO venta)
        {
            await _db.Ventas.AddAsync(_mapper.Map<VentaDTO, Venta>(venta));
            return await Guardar();
        }

        public async Task<int> Eliminar(int id)
        {
            var venta = await _db.Ventas.FindAsync(id);
            if (venta == null)
                return 0;
            _db.Ventas.Remove(venta);
            return await Guardar(); ;
        }

        public async Task<int> Guardar()
        {
            return await _db.SaveChangesAsync();
        }

        public async Task<int> Modificar(int id, VentaDTO venta)
        {
            var entidad = await _db.Ventas.FindAsync(id);
            if (entidad == null)
                return 0;

            entidad.Usuario_id = venta.Usuario_id;
            entidad.Cliente_id = venta.Cliente_id;
            entidad.Producto_id = venta.Producto_id;
            entidad.Cantidad = venta.Cantidad;
            entidad.Fecha = venta.Fecha;

            _db.Ventas.Update(entidad);

            return await Guardar();
        }
            
        public async Task<VentaDTO> Venta(int id)
        {
            var entidad = await _db.Ventas
                .Where(x => x.Id == id).Include(x => x.Usuario).Include(x => x.Cliente)
                .Include(x => x.Producto).FirstOrDefaultAsync();

            var venta = _mapper.Map<Venta, VentaDTO>(entidad);
            return venta;
        }

        public async Task<ICollection<VentaDTO>> Ventas()
        {
            var entidades = await _db.Ventas.Include(x => x.Usuario).Include(x => x.Cliente).Include(x => x.Producto).ToListAsync();
            var ventas = _mapper.Map<ICollection<Venta>, ICollection<VentaDTO>>(entidades);
            return ventas;

        }
    }
}
