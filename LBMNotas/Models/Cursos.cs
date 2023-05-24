namespace LBMNotas.Models
{
    public class Cursos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Año { get; set; }

        public List<AlumnoCurso> alumnoCursos { get; set; }
        public List<Asignaturas> Asignaturas { get; set; }
    }
}
