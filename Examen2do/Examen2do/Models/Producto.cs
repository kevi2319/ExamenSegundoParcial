using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen2do.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Precio { get; set; }

        public string ImagenUrl { get; set; }

        [Required]
        public int IdCategoria { get; set; }

        [ForeignKey(nameof(IdCategoria))]   // ← Indica que esta es la FK
        public Categoria? Categoria { get; set; }
    }
}
