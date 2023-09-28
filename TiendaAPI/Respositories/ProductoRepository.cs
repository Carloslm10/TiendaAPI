using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TiendaAPI.Context;
using TiendaAPI.DTOs;
using TiendaAPI.Entities;
using TiendaAPI.Respositories.Interfaces;

namespace TiendaAPI.Respositories
{
    public class ProductoRepository : IProducto
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductoRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<int> Crear(ProductoDTO producto)
        {
            await _db.Productos.AddAsync(_mapper.Map<ProductoDTO, Producto>(producto));
            return await Guardar();
        }

        public async Task<int> Eliminar(int id)
        {
            var producto = await _db.Productos.FindAsync(id);
            if (producto == null)
                return 0;
            _db.Productos.Remove(producto);
            return await Guardar();
        }

        public async Task<int> Guardar()
        {
            return await _db.SaveChangesAsync();
        }

        public async Task<int> Modificar(int id, ProductoDTO producto)
        {
            var entidad = await _db.Productos.FindAsync(id);
            if(entidad == null)
                return 0;

            entidad.Nombre = producto.Nombre;
            entidad.Descripcion = producto.Descripcion;
            entidad.Precio = producto.Precio;
            entidad.Existencia = producto.Existencia;   
            entidad.Marca_id = producto.Marca_id;
            entidad.Categoria_id = producto.Categoria_id;
            _db.Productos.Update(entidad);

            return await Guardar();
        }

        public async Task<ProductoDTO> Producto(int id)
        {
            var entidad = await _db.Productos.Where(x => x.Id == id)
                .Include(x => x.Marca).Include(x => x.Categoria)
                .FirstOrDefaultAsync();

            var producto = _mapper.Map<Producto, ProductoDTO>(entidad);
            return producto;
        }

        public async Task<ICollection<ProductoDTO>> Productos()
        {
            var entidad = await _db.Productos
                .Include(x => x.Marca).Include(x => x.Categoria).ToListAsync();
            var producto = _mapper.Map<ICollection<Producto>, 
                ICollection<ProductoDTO>>(entidad);
            return producto;
        }
    }
}
