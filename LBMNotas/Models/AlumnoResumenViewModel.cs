namespace LBMNotas.Models
{
    public class AlumnoResumenViewModel
    {
        public Alumnos Alumnos { get; set; }
        public Cursos Cursos { get; set; }
        public List<CalificacionAlumno> calificacionAlumnos { get; set; }
        public List<Asignaturas> Asignaturas { get; set; }
        public List<Unidades> Unidades { get; set; }
        public List<Etapas> Etapas { get; set; }
        public List<NotaFinalUnidad> NotaFinalUnidad { get; set; }
    }
}
