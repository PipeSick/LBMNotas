namespace LBMNotas.Models
{
    public class CursosListadoViewModel
    {
        public List<Cursos> CursosListado { get; set; }
        public List<Asignaturas> AsignaturasListadas { get; set; }
        public List<Alumnos> alumnosListados { get; set; }
        public string mensaje { get; set; }
        public int añoseleccionado { get; set; }

    }
}
