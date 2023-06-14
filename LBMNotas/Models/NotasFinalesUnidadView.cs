namespace LBMNotas.Models
{
    public class NotasFinalesUnidadView
    {
        public List<Unidades> Unidades { get; set; }
        public List<Alumnos> Alumnos { get; set; }
        public List<NotaFinalUnidad> NotaFinalUnidad { get; set; }
        public List<CalificacionAlumno> calificacions { get; set; }
    }
}
