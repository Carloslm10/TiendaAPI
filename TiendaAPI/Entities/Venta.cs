using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaAPI.Entities
{
    public class Venta
    {
        [Key]
        private int Id { get; set; }

        [ForeignKey(nameof(Usuario))]
        private int Usuario_id { get; set; }

        [ForeignKey(nameof(Cliente))]
        private int Cliete_id { get; set; }

        [ForeignKey(nameof(Producto))]
        private int Producto_id {get; set;}
        private int Cantidad { get; set; }
        private DateTime Fecha { get; set; }

        public Usuario Usuario { get; set; }
        public Cliente Cliente { get; set; }
        public Producto Producto { get; set; }

    }
}
