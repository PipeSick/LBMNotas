namespace LBMNotas.Models
{
    public class Cursos
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Año { get; set; }

        public List<Alumnos> Alumnos { get; set; }

        public List<CursoAsignatura> CursoAsignaturas { get; set; }
    }
}
