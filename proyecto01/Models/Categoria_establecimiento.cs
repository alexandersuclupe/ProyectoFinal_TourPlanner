using System.ComponentModel.DataAnnotations;

namespace proyecto01.Models
{
    public class Categoria_establecimiento
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de la categoria establecimiento es obligatorio")]
        public String nombre { get; set; }
    }
}