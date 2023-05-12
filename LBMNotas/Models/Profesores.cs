using System.ComponentModel.DataAnnotations;

namespace LBMNotas.Models
{
    public class Profesores
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El Email es Obligatorio")]
        public string? Correo { get; set; }
        [Required]
        public string? Contraseña { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public List<ProfesorAsignatura>? ProfesoresAsignaturas { get; set; }
    }
}
