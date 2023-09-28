using System.ComponentModel.DataAnnotations.Schema;
using TiendaAPI.Respositories.Interfaces;

namespace TiendaAPI.DTOs
{
    public class VentaDTO
    {
        public int Id { get; set; }

        public int Usuario_id { get; set; }

        public int Cliente_id { get; set; }

        public int Producto_id { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }


        public UsuarioDTO Usuario { get; set; }
        public ClienteDTO Cliente { get; set; }
        public ProductoDTO Producto { get; set; }

    }
}
