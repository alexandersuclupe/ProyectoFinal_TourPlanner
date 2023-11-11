using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto01.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        public String nombre_producto { get; set; }
        [Required(ErrorMessage = "La descripcion del producto es obligatoria")]
        public String descripcion_producto { get; set; }
        [Required(ErrorMessage = "El precio del producto es obligatorio")]
        [Range(0,Double.MaxValue,ErrorMessage ="El precio debe ser mayor a cero")]
        public double precio{ get; set; }
        public String imagenUrl { get; set; }


        public int categoria_id { get; set; }
        [ForeignKey("categoria_id")]
        public virtual Categoria Categoria { get; set; }
    }
}
