using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto01.Models
{
    public class Lugar
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="El nombre del lugar es obligatorio")]
        public String nombre { get; set; }
        [Required(ErrorMessage = "El nombre de la descripción es obligatorio")]
        public String descripcion { get; set; }

        public int ubigeo_id { get; set; }
        [ForeignKey("ubigeo_id")]
        public virtual Ubigeo Ubigeo { get; set; }

        public int categoria_lugar_id { get; set; }
        [ForeignKey("categoria_lugar_id")]
        public virtual Categoria_lugar Categoria_lugar { get; set; }
    }
}
