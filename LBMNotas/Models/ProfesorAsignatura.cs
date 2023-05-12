namespace LBMNotas.Models
{
    public class ProfesorAsignatura
    {
        public int Id { get; set; }
        public int ProfesoresId { get; set; }
        public int AsignaturasId { get; set; }
        public Profesores Profesores { get; set; }
        public Asignaturas Asignaturas { get; set; }
    }
}
