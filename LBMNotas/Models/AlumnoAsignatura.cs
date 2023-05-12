namespace LBMNotas.Models
{
    public class AlumnoAsignatura
    {
        public int Id { get; set; }
        public string AlumnosRut { get; set; }
        public int AsignaturasId { get; set; }
        public Alumnos Alumnos { get; set; }
        public Asignaturas Asignaturas { get; set; }


    }
}
