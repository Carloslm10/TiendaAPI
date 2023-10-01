using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace TiendaAPI.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Existencia { get; set; }
        public int Marca_id { get; set; }
        public int Categoria_id { get; set; }
        public MarcaDTO Marca { get; set; }
        public CategoriaDTO Categoria { get; set; }
    }

    public class GuardarProductoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Existencia { get; set; }
        public int Marca_id { get; set; }
        public int Categoria_id { get; set; }
    }
}
