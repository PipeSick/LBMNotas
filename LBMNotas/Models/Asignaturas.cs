namespace LBMNotas.Models
{
    public class Asignaturas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int UnidadesId { get; set; }
        public Cursos cursos { get; set; }

        public List<CursoAsignatura> CursoAsignaturas { get; set; }
        public List<Unidades> Unidades { get; set; }
        public List<ProfesorAsignatura> ProfesorAsignaturas { get; set; } 

    }
}
