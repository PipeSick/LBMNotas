using System.ComponentModel.DataAnnotations;

namespace LBMNotas.Models
{
    public class Alumnos
    {
        [Key]
        public string Rut { get; set; }
        [Required]
        public string NombreCompleto { get; set; }
        public bool IsActive { get; set; }
        public int CursosId { get; set; }
        public Cursos Cursos { get; set; }
        //public List<AlumnoAsignatura> AlumnosAsignaturas { get; set; }

    }
}
