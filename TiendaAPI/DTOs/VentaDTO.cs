using System.ComponentModel.DataAnnotations.Schema;
using TiendaAPI.Respositories.Interfaces;

namespace TiendaAPI.DTOs
{
    public class VentaDTO
    {
        private int Id { get; set; }

        private int Usuario_id { get; set; }

        private int Cliete_id { get; set; }

        private int Producto_id { get; set; }
        private int Cantidad { get; set; }
        private DateTime Fecha { get; set; }


        public UsuarioDTO Usuario { get; set; }
        public ClienteDTO Cliente { get; set; }
        public ProductoDTO Producto { get; set; }

    }
}
