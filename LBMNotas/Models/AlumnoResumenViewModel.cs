namespace LBMNotas.Models
{
    public class AlumnoResumenViewModel
    {
        public Alumnos Alumnos { get; set; }
        public List<NotaFinalUnidad> UnidadList { get; set;}
        public List<Asignaturas> Asignaturas { get; set; }
        public List<Unidades> Unidades { get; set; }
        public List<Etapas> Etapas { get; set; }

    }
}
