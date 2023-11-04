using System.ComponentModel.DataAnnotations;

namespace proyecto01.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="El nombre de la categoria es obligatorio")]
        public String nombre_categoria { get; set; }
        [Required(ErrorMessage = "El nombre de la abreviatura es obligatorio")]
        public String abreviatura { get; set; }
    }
}
