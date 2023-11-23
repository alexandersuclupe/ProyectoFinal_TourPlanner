using System.ComponentModel.DataAnnotations;

namespace proyecto01.Models
{
    public class Ubigeo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="El Ubigeo es obligatorio")]
        public String ubigeo { get; set; }
        [Required(ErrorMessage = "El nombre del departamento es obligatorio")]
        public String departamento { get; set; }
        [Required(ErrorMessage = "El nombre de la provincia es obligatorio")]
        public String provincia { get; set; }
        [Required(ErrorMessage = "El nombre del distrito es obligatorio")]
        public String distrito { get; set; }
    }
}
