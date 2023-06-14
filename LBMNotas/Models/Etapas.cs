namespace LBMNotas.Models
{
    public class Etapas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Porcentaje { get; set; }
        public int UnidadesId { get; set; }
        public Unidades Unidades { get; set; }

        // Propiedad de navegación hacia la calificación de la etapa
        public List<CalificacionAlumno> Calificacion { get; set; }
    }
}
