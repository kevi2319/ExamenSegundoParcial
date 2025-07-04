using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Examen2do.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }

        // Agrega el '?' para hacer la colección de productos anulable
        public ICollection<Producto>? Productos { get; set; }
    }
}