using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TiendaAPI.Entities
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Existencia { get; set; }
        [ForeignKey(nameof(Marca))]
        public int Marca_id { get; set; }
        [ForeignKey(nameof(Categoria))]
        public int Categoria_id { get; set; }

        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }

        public ICollection<Venta> Ventas { get; set; }
    }
}
