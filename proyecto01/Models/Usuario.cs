using System.ComponentModel.DataAnnotations;

namespace proyecto01.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="El Nombre es obligatorio")]
        public String nombres { get; set; }
        [Required(ErrorMessage = "El Apellido es obligatorio")]
        public String apellidos { get; set; }
        [Required(ErrorMessage = "El nombre del usuario es obligatorio")]
        public String usuario { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public String contraseña { get; set; }
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        public String correo_electronico { get; set; }
        [Required(ErrorMessage = "La fecha de nacimiento es obligatorio")]
        public DateTime fecha_nacimiento { get; set; }
        [Required(ErrorMessage = "La fecha de registro es obligatoria")]
        public DateTime fecha_registro { get; set; }
        [Required(ErrorMessage = "El estado es obligatorio")]
        public bool estado { get; set; }
    }
}
