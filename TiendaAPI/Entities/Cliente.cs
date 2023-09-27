using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TiendaAPI.Entities
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set;}
        public string Dui { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
