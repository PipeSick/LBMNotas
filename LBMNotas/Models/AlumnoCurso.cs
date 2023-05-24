using System.ComponentModel.DataAnnotations;

namespace LBMNotas.Models
{
    public class AlumnoCurso
    {
        public int Id { get; set; }
        public int AlumnosId { get; set; }
        public Alumnos Alumnos { get; set; }
        public int CursosId { get; set; }
        public Cursos Cursos { get; set; }


    }
}
