using Azure;

namespace LBMNotas.Models
{
    public class CalificacionAlumno
    {
        public int Id { get; set; }
        public int AlumnoId { get; set; }
        public Alumnos Alumno { get; set; }

        public int EtapaId { get; set; }
        public Etapas Etapa { get; set; }

        public float Nota { get; set; }
    }
}
