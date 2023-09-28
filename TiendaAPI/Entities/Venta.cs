using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaAPI.Entities
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Usuario))]
        public int Usuario_id { get; set; }

        [ForeignKey(nameof(Cliente))]
        public int Cliente_id { get; set; }

        [ForeignKey(nameof(Producto))]
        public int Producto_id {get; set;}
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }

        public Usuario Usuario { get; set; }
        public Cliente Cliente { get; set; }
        public Producto Producto { get; set; }

    }
}
