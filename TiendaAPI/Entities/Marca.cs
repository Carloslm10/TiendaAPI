using System.ComponentModel.DataAnnotations;

namespace TiendaAPI.Entities
{
    public class Marca
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Producto> Productos { get; set; }
    }
}
