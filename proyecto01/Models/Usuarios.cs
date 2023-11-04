using System.ComponentModel.DataAnnotations;
namespace proyecto01.Models
{
    public class Usuarios
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "El nombre del usuario es obligatorio")]
        public String Nombre_usuario { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public String Nombre { get; set; }
        [Required(ErrorMessage = "El Apellido es obligatorio")]
        public String Apellido { get;set; }
        [Required(ErrorMessage = "El Email es obligatorio")]
        public String Email { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public String Contraseña { get; set; }

    }
}
