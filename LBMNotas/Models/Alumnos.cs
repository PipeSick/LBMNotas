using System.ComponentModel.DataAnnotations;

namespace LBMNotas.Models
{
    public class Alumnos
    {
        [Key]
        public int Id { get; set; }
        public int NumeroLista { get; set; }
        public string Rut { get; set; }
        [Required]
        public string NombreCompleto { get; set; }

        // Propiedad de navegación hacia el curso del alumno.
        public List<AlumnoCurso> alumnoCursos { get; set; }

        // Propiedad de navegación hacia las calificaciones del alumno
        public List<CalificacionAlumno> Calificaciones { get; set; }
        // Propiedad de navegación hacia las notas finales de las unidades
        public List<NotaFinalUnidad> NotaFinalUnidads { get; set; }

    }
}
