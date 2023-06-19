namespace LBMNotas.Models
{
    public class Asignaturas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Unidades> Unidades { get; set; }
        public int CursosId { get; set; }
        public Cursos Cursos { get; set; }
        public List<ProfesorAsignatura> ProfesorAsignaturas { get; set; }

    }
}
