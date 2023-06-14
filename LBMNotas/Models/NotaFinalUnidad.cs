namespace LBMNotas.Models
{
    public class NotaFinalUnidad
    {
        public int Id { get; set; }
        public int UnidadId { get; set; }
        public int AlumnoId { get; set; }
        public Alumnos Alumno { get; set; }
        public float NotaFinal { get; set; }
        public Unidades Unidad { get; set; }
    }
}
